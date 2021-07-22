using UnityEngine;
using System.Collections;
using UnityEditor;

public class copyWindow : EditorWindow
{
    /// 

    /// 位移增量
    /// 

    //private Vector3 _position;
    /// 

    /// 旋转增量
    /// 

    //private Vector3 _rotation;

    /// 

    /// 缩放增量
    /// 

    //private Vector3 _scale;

    /// 

    /// 复制的数量
    /// 

    private int _number;
    private int _gap;
    private float _angle;
    [MenuItem("忍者菜单/批量复制")]
    public static void showWindow()
    {
        copyWindow.CreateInstance<copyWindow>().Show();
    }

    void OnGUI()
    {
        //使用Vector3Field方法绘制 Vector3的输入框，第一个为输入框的标签（显示的名字），第二个参数需要传入需要显示的Vector3值。
        //返回值为一个Vector3，当没有修改的时候，这个值为原来的值，当有修改的时候，这个返回值就是修改后的值。
        //例如，把返回值赋予给_position，这样，输入框有修改的时候，_position能够拿到最新的值。
        //_position = EditorGUILayout.Vector3Field("Position", _position);

        //_rotation = EditorGUILayout.Vector3Field("Rotation", _rotation);

        //_scale = EditorGUILayout.Vector3Field("Scale", _scale);

        //Space的作用是空一行
        //EditorGUILayout.Space();

        //然后使用IntField方法绘制一个int类型的输入框，使用与Vector3相似
        //由于复制的数量不能为负数，所以我们要限制一下修改后的数值
        _number = Mathf.Max(EditorGUILayout.IntField("Number", _number), 0);
        _gap = Mathf.Max(EditorGUILayout.IntField("Gap", _gap), 0);
        EditorGUILayout.Space();

        //BeginHorizontal方法和EndHorizontal是成对存在的，然后他们的作用是水平布局，在两个函数内绘制的UI会限制在一个水平位置。
        //相似的方法还有BeginVertical和EndVertical，是垂直布局。
        EditorGUILayout.BeginHorizontal();

        //绘制一个Generate Button，这里使用GUILayout而不使用EditorGUILayout是因为EditorGUILayout没有Button（不知道原因）。
        //Button方法第一个参数是button显示的label。
        //返回值为Button是否为点击，
        if (GUILayout.Button("向左复制"))
        {
            Generate(1);
        }
        if (GUILayout.Button("向右复制"))
        {
            Generate(2);
        }
        //这里缓存Cancel按钮的状态，在EndHorizontal之后再调用Cancel方法。
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();

        if (GUILayout.Button("向上复制"))
        {
            Generate(3);
        }
        if (GUILayout.Button("向下复制"))
        {
            Generate(4);
        }
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();

        _angle = Mathf.Max(EditorGUILayout.FloatField("Angle", _angle), 0);
        if (GUILayout.Button("自定义复制"))
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
        //上一篇有介绍过Selection.activeGameObject是选中的对象，然后Selection.gameObjects是多选时，所有选中的对象。
        //因为有可能是多个对象同时复制，所以使用选中对象组
        Vector3 _position = Vector3.zero;
        GameObject[] selectGameObjects = Selection.gameObjects;
        int len = selectGameObjects.Length;

        for (int i = 0; i < len; i++)
        {
            GameObject selectGameObject = selectGameObjects[i];

            for (int j = 1; j < _number; j++)
            {
                //根据选中对象，实例化对象，然后根据索引和增量，设置移动、旋转、缩放

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

                //Undo是Unity3d用于设置步骤，执行/撤销等
                //RegisterCreatedObjectUndo是注册一个新创建的对象的步骤，然后名字为“Batching Create GameObject”，用于
                Undo.RegisterCreatedObjectUndo(gameObject, "Batching Create GameObject");
            }
        }
    }

    /// 
    /// 取消操作
    /// 同ctrl + z
    /// 

    private void Cancel()
    {
        //PerformUndo作用跟ctrl + z一样
        Undo.PerformUndo();
    }

}

