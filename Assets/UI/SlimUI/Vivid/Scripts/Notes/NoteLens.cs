using UnityEngine;

[AddComponentMenu("Miscellaneous/Inspector Text Info Note")]
public class NoteLens : MonoBehaviour{
    public string TextInfo = "The LensDirt game object can be safely enabled or disabled to your liking.";
    public string spaceMessage = "";

    private void Awake(){
        this.enabled = false; 
    }
}