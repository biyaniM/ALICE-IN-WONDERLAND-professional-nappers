using UnityEngine;

[AddComponentMenu("Miscellaneous/Inspector Text Info Note")]
public class NotePost : MonoBehaviour{
    public string TextInfo = "If you are using LWRP or URP, you can disable this POST object and delete the PostProcessLayer missing reference because those render pipelines have their own Post Processing system";
    public string spaceMessage = "";

    private void Awake(){
        this.enabled = false; 
    }
}