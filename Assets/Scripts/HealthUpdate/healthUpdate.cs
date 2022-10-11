using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.EventSystems;

public class healthUpdate : MonoBehaviour
{
    [SerializeField] GameOverHUD gameOverHUD;
    [SerializeField] bool gameOverCheck;
    [SerializeField] CountDownTimer timer;
    [SerializeField] Transform player;

    public HealthBar healthBar;
    public int maxHealth = 100;
    public int currentHealth = 100;

    private bool respawning;
    private static Vector3 respawnPoint;
    // Start is called before the first frame update
    void Start()
    {  
        gameOverCheck = false;  
        respawnPoint = player.transform.position;      
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth <= 0) {
            respawn();
            // destroy the player
            // Destroy(gameObject);   
            // gameOverHUD.Setup();
            
            //gameObject.SetActiveRecursively(false);
            //respawn();
            // if(gameOverCheck == false){
            //     runGameOverHud();
            //     // stop timer
            //     timer.pauseTimer();
            // }
        }
    }

    public void respawn() {
        player.transform.position = respawnPoint;
        Physics.SyncTransforms();
        currentHealth = maxHealth; 
        updateHealth(currentHealth);
        
        //gameObject.SetActiveRecursively(true);
        // Debug.Log("I got here bro!");
        // Debug.Log(respawnPoint);
        // player.transform.position = respawnPoint;
        // Debug.Log(gameObject.transform.position);
        // updateHealth(maxHealth);
    }

    public static void setSpawnPoint(Vector3 spawnPoint) {
        respawnPoint = spawnPoint;
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
            Destroy(col.gameObject);
            Debug.Log("Enemy bullet destroyed!");
            Debug.Log(col.gameObject);
            currentHealth = currentHealth - 20;
            updateHealth(currentHealth);
            return;            
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
