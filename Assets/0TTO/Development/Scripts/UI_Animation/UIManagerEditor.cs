using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;


#if UNITY_EDITOR

[CustomEditor(typeof(UIAnimationManager))]
public class UIManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        UIAnimationManager targetScript = (UIAnimationManager)target;
        
        if (GUILayout.Button("Open ReadMe"))
        {
            Application.OpenURL("https://docs.google.com/document/d/17Jo8PX4ugHpw6QIDY779Fv-qGyy2ZCwhHVW2cfVGByc/edit?usp=sharing");
        }
    }
}

#endif