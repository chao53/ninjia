using UnityEngine;
using System.Collections;
using UnityEditor;

public class copyWindow : EditorWindow
{
    /// 

    /// λ������
    /// 

    //private Vector3 _position;
    /// 

    /// ��ת����
    /// 

    //private Vector3 _rotation;

    /// 

    /// ��������
    /// 

    //private Vector3 _scale;

    /// 

    /// ���Ƶ�����
    /// 

    private int _number;
    private int _gap;
    private float _angle;
    [MenuItem("���߲˵�/��������")]
    public static void showWindow()
    {
        copyWindow.CreateInstance<copyWindow>().Show();
    }

    void OnGUI()
    {
        //ʹ��Vector3Field�������� Vector3������򣬵�һ��Ϊ�����ı�ǩ����ʾ�����֣����ڶ���������Ҫ������Ҫ��ʾ��Vector3ֵ��
        //����ֵΪһ��Vector3����û���޸ĵ�ʱ�����ֵΪԭ����ֵ�������޸ĵ�ʱ���������ֵ�����޸ĺ��ֵ��
        //���磬�ѷ���ֵ�����_position����������������޸ĵ�ʱ��_position�ܹ��õ����µ�ֵ��
        //_position = EditorGUILayout.Vector3Field("Position", _position);

        //_rotation = EditorGUILayout.Vector3Field("Rotation", _rotation);

        //_scale = EditorGUILayout.Vector3Field("Scale", _scale);

        //Space�������ǿ�һ��
        //EditorGUILayout.Space();

        //Ȼ��ʹ��IntField��������һ��int���͵������ʹ����Vector3����
        //���ڸ��Ƶ���������Ϊ��������������Ҫ����һ���޸ĺ����ֵ
        _number = Mathf.Max(EditorGUILayout.IntField("Number", _number), 0);
        _gap = Mathf.Max(EditorGUILayout.IntField("Gap", _gap), 0);
        EditorGUILayout.Space();

        //BeginHorizontal������EndHorizontal�ǳɶԴ��ڵģ�Ȼ�����ǵ�������ˮƽ���֣������������ڻ��Ƶ�UI��������һ��ˮƽλ�á�
        //���Ƶķ�������BeginVertical��EndVertical���Ǵ�ֱ���֡�
        EditorGUILayout.BeginHorizontal();

        //����һ��Generate Button������ʹ��GUILayout����ʹ��EditorGUILayout����ΪEditorGUILayoutû��Button����֪��ԭ�򣩡�
        //Button������һ��������button��ʾ��label��
        //����ֵΪButton�Ƿ�Ϊ�����
        if (GUILayout.Button("������"))
        {
            Generate(1);
        }
        if (GUILayout.Button("���Ҹ���"))
        {
            Generate(2);
        }
        //���ﻺ��Cancel��ť��״̬����EndHorizontal֮���ٵ���Cancel������
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();

        if (GUILayout.Button("���ϸ���"))
        {
            Generate(3);
        }
        if (GUILayout.Button("���¸���"))
        {
            Generate(4);
        }
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();

        _angle = Mathf.Max(EditorGUILayout.FloatField("Angle", _angle), 0);
        if (GUILayout.Button("�Զ��帴��"))
        {
            Generate(5);
        }

        EditorGUILayout.EndHorizontal();

        bool isCancel = GUILayout.Button("Cancel");
        if (isCancel)
        {
            Cancel();
        }
    }

    private void Generate(int x)
    {
        //��һƪ�н��ܹ�Selection.activeGameObject��ѡ�еĶ���Ȼ��Selection.gameObjects�Ƕ�ѡʱ������ѡ�еĶ���
        //��Ϊ�п����Ƕ������ͬʱ���ƣ�����ʹ��ѡ�ж�����
        Vector3 _position = Vector3.zero;
        GameObject[] selectGameObjects = Selection.gameObjects;
        int len = selectGameObjects.Length;

        for (int i = 0; i < len; i++)
        {
            GameObject selectGameObject = selectGameObjects[i];

            for (int j = 1; j < _number; j++)
            {
                //����ѡ�ж���ʵ��������Ȼ����������������������ƶ�����ת������

                switch (x)
                {
                    case 1:
                        _position = new Vector3(-1 * selectGameObject.GetComponent<Renderer>().bounds.size.x, 0, 0);
                        break;
                    case 2:
                        _position = new Vector3(1 * selectGameObject.GetComponent<Renderer>().bounds.size.x, 0, 0);
                        break;
                    case 3:
                        _position = new Vector3(0, 1 * selectGameObject.GetComponent<Renderer>().bounds.size.y, 0);
                        break;
                    case 4:
                        _position = new Vector3(0, -1 * selectGameObject.GetComponent<Renderer>().bounds.size.y, 0);
                        break;
                    case 5:
                        _position = new Vector3(Mathf.Cos(Mathf.PI * _angle / 180) * selectGameObject.GetComponent<Renderer>().bounds.size.x, Mathf.Sin(Mathf.PI * _angle / 180) * selectGameObject.GetComponent<Renderer>().bounds.size.y, 0);
                        break;
                }



                GameObject gameObject = GameObject.Instantiate(selectGameObject);

                gameObject.transform.SetParent(selectGameObject.transform.parent);

                gameObject.transform.localPosition = selectGameObject.transform.localPosition + _position * (_gap + 1) * j;

                //gameObject.transform.localRotation = selectGameObject.transform.localRotation * Quaternion.Euler(_rotation * j);

                //gameObject.transform.localScale = selectGameObject.transform.localScale + _scale * j;

                gameObject.name = selectGameObject.name;

                //Undo��Unity3d�������ò��裬ִ��/������
                //RegisterCreatedObjectUndo��ע��һ���´����Ķ���Ĳ��裬Ȼ������Ϊ��Batching Create GameObject��������
                Undo.RegisterCreatedObjectUndo(gameObject, "Batching Create GameObject");
            }
        }
    }

    /// 
    /// ȡ������
    /// ͬctrl + z
    /// 

    private void Cancel()
    {
        //PerformUndo���ø�ctrl + zһ��
        Undo.PerformUndo();
    }

}

