using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.EventSystems;

public class healthUpdate : MonoBehaviour
{
    [SerializeField] GameOverHUD gameOverHUD;
    [SerializeField] bool gameOverCheck;
    [SerializeField] public CountDownTimer timer;
    private Player hud;

    public HealthBar healthBar;
    public int maxHealth = 100;
    public int currentHealth = 100;
    // Start is called before the first frame update
    void Start()
    {  
        gameOverCheck = false;        
        hud = GameObject.Find("HUD").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth <= 0) {
            // destroy the player
            // Destroy(gameObject);   
            // gameOverHUD.Setup();
            gameObject.SetActiveRecursively(false);
            if(gameOverCheck == false){
                runGameOverHud();
                // stop timer
                timer.pauseTimer();
            }
        }
    }

    public void runGameOverHud(){
        Debug.Log("Game over hud from health update!!");
        gameOverHUD.Setup();
        gameOverCheck = true;
        // destroy the player
        // Destroy(gameObject);
    }

    public void OnCollisionEnter(Collision col) {
        Debug.Log("Player got hit");
        if(col.gameObject.tag == "enemyBullet") {
            hud.ShowAlert("HP: -10");
            //Destroy(col.gameObject);
            //Debug.Log("Enemy bullet destroyed!");
            Debug.Log("Bullet: " + col.gameObject);
            currentHealth = currentHealth - 10;
            updateHealth(currentHealth);
            return;            
        }
    }

    private void OnCollisionExit(Collision col) {
        Debug.Log("Collision Exit!!!");
        if(col.gameObject.CompareTag("enemyBullet")) {
            Debug.Log("Enemy bullet destroyed!");
            hud.CloseAlert();
            Destroy(col.gameObject);     
        }    
    }


    public void updateHealth(int health) {
        Debug.Log("Set health Called");
        healthBar.SetHealth(health);
        Debug.Log("Health set");
    }
    //     public void OnCollisionEnter(Collision col) {
    //     Debug.Log("Got Hit!!!!");
    //     if(col.gameObject.tag == "enemyBullet") {
    //         Destroy(col.gameObject);
    //         Debug.Log("Enemy YOOOOO");
    //         Debug.Log(col.gameObject);
    //         currentHealth = currentHealth - 20;
    //         Debug.Log(currentHealth);
    //         healthBar.SetHealth(currentHealth);
            
    //     }
    // }
}
