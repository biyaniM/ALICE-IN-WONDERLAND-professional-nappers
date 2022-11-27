using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
namespace Polyperfect.People
{
    [CustomEditor(typeof(AtlasGenerator))]
    public class AtlasGenerator_Editor : Editor
    {
        static float timer;
        public enum TextureSizes
        {
            _8 = 8,
            _16 = 16,
            _32 = 32,
            _64 = 64,
            _128 = 128,
            _256 = 256,
            _512 = 512,
            _1024 = 1024,
            _2048 = 2048
        }

        TextureSizes textureSize = TextureSizes._256;

        public override void OnInspectorGUI()
        {
            var myTarget = (AtlasGenerator)target;

            EditorGUI.BeginChangeCheck();
            textureSize = (TextureSizes)EditorGUILayout.EnumPopup("Texture Size", textureSize);
            if (EditorGUI.EndChangeCheck())
            {
                myTarget.textureSize = (int)textureSize;
            }

            EditorGUILayout.BeginVertical();
            var index = 0;
            var width = EditorGUIUtility.currentViewWidth / 10;
            for (int y = 0; y < 8; y++)
            {
                EditorGUILayout.BeginHorizontal();
                for (int x = 0; x < 8; x++)
                {
                    EditorGUI.BeginChangeCheck();
                    var newCol = EditorGUILayout.ColorField(GUIContent.none, myTarget.colors[index], false, false, false, GUILayout.Width(width));
                    if (EditorGUI.EndChangeCheck())
                    {
                        myTarget.colors[index] = newCol;
                    }
                    index++;
                }
                EditorGUILayout.EndHorizontal();
            }
            EditorGUILayout.EndVertical();

            EditorGUILayout.Space();
            if (GUILayout.Button("Generate Atlas"))
            {
                myTarget.MakeTexture();
            }

            EditorGUILayout.Space();
        }
    }
}
#endif