using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour
{
    // Start is called before the first frame update
    public GrayScaleFunctions grayScaleFunctions;
    public int[] indexes;
    public int numberOfCoins;

    void Awake() {
        grayScaleFunctions.fadeAllExceptCoins();
        grayScaleFunctions.setInitialShadeFactor(numberOfCoins);
       // fadeToGray.setColorToCoins(indexes);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
