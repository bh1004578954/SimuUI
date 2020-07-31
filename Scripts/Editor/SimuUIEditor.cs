using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MainUI))]
public class SimuUIEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        MainUI ui = (MainU)target;

        if (GUILayout.Button("Set obj"))
        {
            GameObject go = AssetDatabase.LoadAssetAtPath<GameObject>("Packages/com.autocore.SimuUI/Prefabs/SimuUI.prefab");
            Instantiate(go);
        }
    }
}
