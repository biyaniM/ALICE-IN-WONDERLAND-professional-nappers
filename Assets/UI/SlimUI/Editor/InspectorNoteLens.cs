using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(NoteLens))]
public class InspectorNoteLens : Editor{
    public override void OnInspectorGUI(){
        NoteLens inMyScript = (NoteLens)target;

        EditorGUILayout.LabelField("");
        EditorGUILayout.HelpBox(inMyScript.TextInfo, MessageType.Info);
        EditorGUILayout.LabelField("");
    }
}