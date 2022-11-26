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
    int health;
    ThirdPersonShooterController shootingComponent;
    SendToGoogle analyticsComponent;
    healthUpdate healthComponent;
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
        healthComponent = GetComponent<healthUpdate>();

    }
    

    public void OnTriggerEnter(Collider col){
        // Debug.Log("collider: "+col.name);
        // GameObject finishBoundary = GameObject.Find("FinishBoundary");
        // get ammo balance
        ammoBalance = shootingComponent.currentAmmo;
        numKill = player.GetNumberOfKill();
        timer = timerComponent.remainingDuration+1;
        health = healthComponent.currentHealth;
        if (levelOverCheck == false){
            if(col.gameObject.tag == "LevelCompleteTag"){
                levelOverCheck = true;

                try {FindObjectOfType<AudioManager>().play("level complete");}
                catch (System.NullReferenceException e) { Debug.LogWarning("Level Complete sound not appointed in "+gameObject.scene+"\n"+e.ToString()); }

                // capture the analytics
                analyticsComponent.Send(SceneManager.GetActiveScene().buildIndex.ToString(), ammoBalance.ToString(), "Completed", timer.ToString(), numKill.ToString(), health.ToString(), "NA");

                //! show the level complete HUD
                levelCompleteScreen.Setup();
                //Set game status
                player.SetGameStatus(true);
            }
        }
        // show the finishboundary again
        // finishBoundary.GetComponent<BoxCollider>().enabled = true;
    }
}
