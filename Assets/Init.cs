using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour
{
    // Start is called before the first frame update
    public FadeToGray fadeToGray;
    public int[] indexes;

    void Awake() {
        fadeToGray.fadeAll();
        fadeToGray.setColorToCoins(indexes);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
