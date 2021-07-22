using UnityEngine;
using System.Collections;
using UnityEditor;


public class prefabsWindow : EditorWindow
{
    private Vector3 _position;
    private float _angle;

    [MenuItem("忍者菜单/预制体目录")]

    public static void showWindow()
    {
        copyWindow.CreateInstance<prefabsWindow>().Show();
    }

    void OnGUI()
    {

        _position = EditorGUILayout.Vector2Field("Position", _position);
        _angle = EditorGUILayout.FloatField("Angle", _angle);

        //Space的作用是空一行
        EditorGUILayout.Space();

        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("石头方块"))
        {
            GameObject obj = GameObject.Instantiate(Resources.Load<GameObject>("prefabs/stone"), new Vector3(_position.x, _position.y, 0), Quaternion.Euler(new Vector3(0, 0, _angle)));
            obj.name = "stone";
            Undo.RegisterCreatedObjectUndo(obj, "Batching Create GameObject");
        }
        if (GUILayout.Button("草地方块"))
        {
            GameObject obj = GameObject.Instantiate(Resources.Load<GameObject>("prefabs/glass"), new Vector3(_position.x, _position.y, 0), Quaternion.Euler(new Vector3(0, 0, _angle)));
            obj.name = "glass";
            Undo.RegisterCreatedObjectUndo(obj, "Batching Create GameObject");
        }
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("泥土方块"))
        {
            GameObject obj = GameObject.Instantiate(Resources.Load<GameObject>("prefabs/dirt"), new Vector3(_position.x, _position.y, 0), Quaternion.Euler(new Vector3(0, 0, _angle)));
            obj.name = "dirt";
            Undo.RegisterCreatedObjectUndo(obj, "Batching Create GameObject");
        }
        if (GUILayout.Button("树枝方块(假)"))
        {
            GameObject obj = GameObject.Instantiate(Resources.Load<GameObject>("prefabs/branch"), new Vector3(_position.x, _position.y, 0), Quaternion.Euler(new Vector3(0, 0, _angle)));
            obj.name = "branch";
            Undo.RegisterCreatedObjectUndo(obj, "Batching Create GameObject");
        }
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("竹刺"))
        {
            GameObject obj = GameObject.Instantiate(Resources.Load<GameObject>("prefabs/bamboo"), new Vector3(_position.x, _position.y, 0), Quaternion.Euler(new Vector3(0, 0, _angle)));
            obj.name = "bamboo";
            Undo.RegisterCreatedObjectUndo(obj, "Batching Create GameObject");
        }
        if (GUILayout.Button("荆棘方块"))
        {
            GameObject obj = GameObject.Instantiate(Resources.Load<GameObject>("prefabs/thorn"), new Vector3(_position.x, _position.y, 0), Quaternion.Euler(new Vector3(0, 0, _angle)));
            obj.name = "thorn";
            Undo.RegisterCreatedObjectUndo(obj, "Batching Create GameObject");
        }
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("滚动巨石"))
        {
            GameObject obj = GameObject.Instantiate(Resources.Load<GameObject>("prefabs/rock"), new Vector3(_position.x, _position.y, 0), Quaternion.Euler(new Vector3(0, 0, _angle)));
            obj.name = "rock";
            Undo.RegisterCreatedObjectUndo(obj, "Batching Create GameObject");
        }
        if (GUILayout.Button("亭子"))
        {
            GameObject obj = GameObject.Instantiate(Resources.Load<GameObject>("prefabs/pavilion"), new Vector3(_position.x, _position.y, 0), Quaternion.Euler(new Vector3(0, 0, _angle)));
            obj.name = "pavilion";
            Undo.RegisterCreatedObjectUndo(obj, "Batching Create GameObject");
        }
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("佛身"))
        {
            GameObject obj = GameObject.Instantiate(Resources.Load<GameObject>("prefabs/buddhaBody"), new Vector3(_position.x, _position.y, 0), Quaternion.Euler(new Vector3(0, 0, _angle)));
            obj.name = "buddhaBody";
            Undo.RegisterCreatedObjectUndo(obj, "Batching Create GameObject");
        }
        if (GUILayout.Button("佛头"))
        {
            GameObject obj = GameObject.Instantiate(Resources.Load<GameObject>("prefabs/buddhaHead"), new Vector3(_position.x, _position.y, 0), Quaternion.Euler(new Vector3(0, 0, _angle)));
            obj.name = "buddhaHead";
            Undo.RegisterCreatedObjectUndo(obj, "Batching Create GameObject");
        }
        EditorGUILayout.EndHorizontal();
        if (GUILayout.Button("空气墙方块"))
        {
            GameObject obj = GameObject.Instantiate(Resources.Load<GameObject>("prefabs/air"), new Vector3(_position.x, _position.y, 0), Quaternion.Euler(new Vector3(0, 0, _angle)));
            obj.name = "air";
            Undo.RegisterCreatedObjectUndo(obj, "Batching Create GameObject");
        }

        EditorGUILayout.Space();

        if (GUILayout.Button("清除场景并生成基础场景(慎用!!)"))
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
        //PerformUndo作用跟ctrl + z一样
        Undo.PerformUndo();
    }

}
