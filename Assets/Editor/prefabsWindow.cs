using UnityEngine;
using System.Collections;
using UnityEditor;


public class prefabsWindow : EditorWindow
{
    private Vector3 _position;
    private float _angle;

    [MenuItem("���߲˵�/Ԥ����Ŀ¼")]

    public static void showWindow()
    {
        copyWindow.CreateInstance<prefabsWindow>().Show();
    }

    void OnGUI()
    {

        _position = EditorGUILayout.Vector2Field("Position", _position);
        _angle = EditorGUILayout.FloatField("Angle", _angle);

        //Space�������ǿ�һ��
        EditorGUILayout.Space();

        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("ʯͷ����"))
        {
            GameObject obj = GameObject.Instantiate(Resources.Load<GameObject>("prefabs/stone"), new Vector3(_position.x, _position.y, 0), Quaternion.Euler(new Vector3(0, 0, _angle)));
            obj.name = "stone";
            Undo.RegisterCreatedObjectUndo(obj, "Batching Create GameObject");
        }
        if (GUILayout.Button("�ݵط���"))
        {
            GameObject obj = GameObject.Instantiate(Resources.Load<GameObject>("prefabs/glass"), new Vector3(_position.x, _position.y, 0), Quaternion.Euler(new Vector3(0, 0, _angle)));
            obj.name = "glass";
            Undo.RegisterCreatedObjectUndo(obj, "Batching Create GameObject");
        }
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("��������"))
        {
            GameObject obj = GameObject.Instantiate(Resources.Load<GameObject>("prefabs/dirt"), new Vector3(_position.x, _position.y, 0), Quaternion.Euler(new Vector3(0, 0, _angle)));
            obj.name = "dirt";
            Undo.RegisterCreatedObjectUndo(obj, "Batching Create GameObject");
        }
        if (GUILayout.Button("��֦����(��)"))
        {
            GameObject obj = GameObject.Instantiate(Resources.Load<GameObject>("prefabs/branch"), new Vector3(_position.x, _position.y, 0), Quaternion.Euler(new Vector3(0, 0, _angle)));
            obj.name = "branch";
            Undo.RegisterCreatedObjectUndo(obj, "Batching Create GameObject");
        }
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("���"))
        {
            GameObject obj = GameObject.Instantiate(Resources.Load<GameObject>("prefabs/bamboo"), new Vector3(_position.x, _position.y, 0), Quaternion.Euler(new Vector3(0, 0, _angle)));
            obj.name = "bamboo";
            Undo.RegisterCreatedObjectUndo(obj, "Batching Create GameObject");
        }
        if (GUILayout.Button("��������"))
        {
            GameObject obj = GameObject.Instantiate(Resources.Load<GameObject>("prefabs/thorn"), new Vector3(_position.x, _position.y, 0), Quaternion.Euler(new Vector3(0, 0, _angle)));
            obj.name = "thorn";
            Undo.RegisterCreatedObjectUndo(obj, "Batching Create GameObject");
        }
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("������ʯ"))
        {
            GameObject obj = GameObject.Instantiate(Resources.Load<GameObject>("prefabs/rock"), new Vector3(_position.x, _position.y, 0), Quaternion.Euler(new Vector3(0, 0, _angle)));
            obj.name = "rock";
            Undo.RegisterCreatedObjectUndo(obj, "Batching Create GameObject");
        }
        if (GUILayout.Button("ͤ��"))
        {
            GameObject obj = GameObject.Instantiate(Resources.Load<GameObject>("prefabs/pavilion"), new Vector3(_position.x, _position.y, 0), Quaternion.Euler(new Vector3(0, 0, _angle)));
            obj.name = "pavilion";
            Undo.RegisterCreatedObjectUndo(obj, "Batching Create GameObject");
        }
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("����"))
        {
            GameObject obj = GameObject.Instantiate(Resources.Load<GameObject>("prefabs/buddhaBody"), new Vector3(_position.x, _position.y, 0), Quaternion.Euler(new Vector3(0, 0, _angle)));
            obj.name = "buddhaBody";
            Undo.RegisterCreatedObjectUndo(obj, "Batching Create GameObject");
        }
        if (GUILayout.Button("��ͷ"))
        {
            GameObject obj = GameObject.Instantiate(Resources.Load<GameObject>("prefabs/buddhaHead"), new Vector3(_position.x, _position.y, 0), Quaternion.Euler(new Vector3(0, 0, _angle)));
            obj.name = "buddhaHead";
            Undo.RegisterCreatedObjectUndo(obj, "Batching Create GameObject");
        }
        EditorGUILayout.EndHorizontal();
        if (GUILayout.Button("����ǽ����"))
        {
            GameObject obj = GameObject.Instantiate(Resources.Load<GameObject>("prefabs/air"), new Vector3(_position.x, _position.y, 0), Quaternion.Euler(new Vector3(0, 0, _angle)));
            obj.name = "air";
            Undo.RegisterCreatedObjectUndo(obj, "Batching Create GameObject");
        }

        EditorGUILayout.Space();

        if (GUILayout.Button("������������ɻ�������(����!!)"))
        {
            GenerateBase();
        }
        EditorGUILayout.Space();
        bool isCancel = GUILayout.Button("Cancel");
        if (isCancel)
        {
            Cancel();
        }




        //Debug.Log(Event.current.mousePosition);
        
    }

    private void GenerateBase()
    {
        foreach (GameObject objj in UnityEngine.Object.FindObjectsOfType(typeof(GameObject)))
        {
            DestroyImmediate(objj);
        }
        GameObject ninjia = GameObject.Instantiate(Resources.Load<GameObject>("prefabs/ninjia"));
        ninjia.name = "ninjia";
        GameObject camera = GameObject.Instantiate(Resources.Load<GameObject>("prefabs/Main Camera"));
        camera.name = "Main Camera";
        GameObject background = GameObject.Instantiate(Resources.Load<GameObject>("prefabs/background"));
        background.name = "background";
        GameObject light = GameObject.Instantiate(Resources.Load<GameObject>("prefabs/Directional Light"));
        light.name = "Directional Light";
    }

    private void Cancel()
    {
        //PerformUndo���ø�ctrl + zһ��
        Undo.PerformUndo();
    }

}
