using UnityEngine;
using UnityEditor;

public class SlimUIWindow : EditorWindow {

	//string myString = "Hello";

	[MenuItem("Window/SlimUI/Online Documentation")]
	public static void ShowWindow(){
		//GetWindow<SlimUIWindow>("Example");
		Application.OpenURL("https://www.slimui.com/documentation");
	}
/* UNDER CONSTRUCTION - Coming in later update
	void OnGUI(){
		GUILayout.Label("SlimUI Control Panel", EditorStyles.boldLabel);

		myString = EditorGUILayout.TextField("Name", myString);
	}
*/
}
