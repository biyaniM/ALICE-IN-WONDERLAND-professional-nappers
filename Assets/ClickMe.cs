using UnityEngine;

public class ClickMe : MonoBehaviour
{
    public int numberOfCoins;

    private void OnMouseUpAsButton()
    {   
        float initialShadeFactor = FindObjectOfType<GrayScaleFunctions>().getInitialShadeFactor(numberOfCoins);
        float shadeFactor = FindObjectOfType<GrayScaleFunctions>().getShadeFactor();
        float newShadeFactor = shadeFactor - initialShadeFactor;
        Debug.Log("New Values");
        Debug.Log(newShadeFactor); 
        Debug.Log(initialShadeFactor);
        Debug.Log(shadeFactor);
            if(newShadeFactor >= 0) {
                FindObjectOfType<GrayScaleFunctions>().setShadeFactor(newShadeFactor);
                FindObjectOfType<GrayScaleFunctions>().colorAll();
            }
    }
}