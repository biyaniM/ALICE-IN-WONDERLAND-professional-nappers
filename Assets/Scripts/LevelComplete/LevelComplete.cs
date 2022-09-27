using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    public bool levelOverCheck;
    int ammoBalance;
    ThirdPersonShooterController shootingComponent;
    SendToGoogle analyticsComponent;
    [SerializeField] LevelCompleteScreen levelCompleteScreen;

    // Start is called before the first frame update
    void Start()
    {
        levelOverCheck = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake(){
        shootingComponent = GetComponent<ThirdPersonShooterController>();
        analyticsComponent = GetComponent<SendToGoogle>();
    }
    

    public void OnTriggerEnter(Collider col){
        Debug.Log("collider: "+col.name);
        // GameObject finishBoundary = GameObject.Find("FinishBoundary");
        // get ammo balance
        ammoBalance = shootingComponent.currentAmmo;
        if(levelOverCheck == false){
            if(col.gameObject.tag == "LevelCompleteTag"){
                Debug.Log("reached level over loc!");
                levelOverCheck = true;

                // capture the analytics
                analyticsComponent.Send("1", ammoBalance.ToString(), "0");

                //! show the level complete HUD
                levelCompleteScreen.Setup();

            }
        }
        // show the finishboundary again
        // finishBoundary.GetComponent<BoxCollider>().enabled = true;
    }
}
