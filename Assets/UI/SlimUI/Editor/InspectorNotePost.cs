using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(NotePost))]
public class InspectorNotePost : Editor{
    public override void OnInspectorGUI(){
        NotePost inMyScript = (NotePost)target;

        EditorGUILayout.LabelField("");
        EditorGUILayout.HelpBox(inMyScript.TextInfo, MessageType.Info);
        EditorGUILayout.LabelField("");
    }
}