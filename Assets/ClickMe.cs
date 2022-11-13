using UnityEngine;

public class ClickMe : MonoBehaviour
{
    public int index = 0;

    private void OnMouseUpAsButton()
    {
        FindObjectOfType<FadeToGray>().colorAll();
    }
}