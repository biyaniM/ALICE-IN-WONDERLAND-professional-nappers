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

    public HealthBar healthBar;
    public int maxHealth = 100;
    public int currentHealth = 100;
    // Start is called before the first frame update
    void Start()
    {  
        gameOverCheck = false;        
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
            Destroy(col.gameObject);
            Debug.Log("Enemy bullet destroyed!");
            Debug.Log(col.gameObject);
            currentHealth = currentHealth - 10;
            updateHealth(currentHealth);
            return;            
        }
    }

    public void updateHealth(int health) {
        Debug.Log("Set health Called");
        healthBar.SetHealth(health);
        Debug.Log("Health set");
    }

    public void changeCurrentAmmo(int health){
        Debug.Log("Updated health ::: "+ health);
        currentHealth += health;
        updateHealth(health: currentHealth);
        Debug.Log("Current health ::: "+ currentHealth);
    }
    
}
