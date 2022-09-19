using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    public bool levelOverCheck = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "LevelCompleteTag"){
            Debug.Log("reached level over loc!"); 
            levelOverCheck = true;

            //! show the level complete HUD

        }
    }
}
