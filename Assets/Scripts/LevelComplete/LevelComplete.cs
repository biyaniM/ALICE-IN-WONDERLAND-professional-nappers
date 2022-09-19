using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LevelComplete : MonoBehaviour
{
    public bool levelOverCheck = false;
    int ammoBalance;
    int i = 1;
    

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
            Debug.Log(i);
            i = i + 1;
            levelOverCheck = true;
            ThirdPersonShooterController shootingComponent = GetComponent<ThirdPersonShooterController>();
            ammoBalance = shootingComponent.currentAmmo;
            SendToGoogle analyticsComponent = GetComponent<SendToGoogle>();
            analyticsComponent.Send("1", ammoBalance.ToString(), "0");
            //! show the level complete HUD

        }
    }
}
