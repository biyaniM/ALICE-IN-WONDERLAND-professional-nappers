using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    public bool levelOverCheck;
    int ammoBalance;
    int numKill;
    int timer;
    ThirdPersonShooterController shootingComponent;
    SendToGoogle analyticsComponent;
    [SerializeField] LevelCompleteScreen levelCompleteScreen;
    [SerializeField] CountDownTimer timerComponent;
    
    Player player;

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
        player = GameObject.Find("HUD").GetComponent<Player>();
        
    }
    

    public void OnTriggerEnter(Collider col){
        Debug.Log("collider: "+col.name);
        // GameObject finishBoundary = GameObject.Find("FinishBoundary");
        // get ammo balance
        ammoBalance = shootingComponent.currentAmmo;
        numKill = player.GetNumberOfKill();
        timer = timerComponent.remainingDuration+1;
        if (levelOverCheck == false){
            if(col.gameObject.tag == "LevelCompleteTag"){
                Debug.Log("reached level over loc!");
                levelOverCheck = true;
                Debug.Log("Number of Enemy Kill:" + numKill);
                Debug.Log("Time Left:" + timer);
                // capture the analytics
                analyticsComponent.Send(SceneManager.GetActiveScene().buildIndex.ToString(), ammoBalance.ToString(), "0", timer.ToString(), numKill.ToString());

                //! show the level complete HUD
                levelCompleteScreen.Setup();
            }
        }
        // show the finishboundary again
        // finishBoundary.GetComponent<BoxCollider>().enabled = true;
    }
}
