using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.SceneManagement;
public class healthUpdate : MonoBehaviour
{
    [SerializeField] GameOverHUD gameOverHUD;
    [SerializeField] bool gameOverCheck;
    [SerializeField] public CountDownTimer timer;
    private Player player;
    public HealthBar healthBar;
    SendToGoogle analyticsComponent;
    public GameObject playerArmature;

    public int maxHealth = 100;
    public int currentHealth = 100;

    private bool respawning;
    private static Vector3 respawnPoint;
    private int numberOfTimesSpawned;
    // Start is called before the first frame update
    void Start()
    {  
        gameOverCheck = false;       
        player = GameObject.Find("HUD").GetComponent<Player>();
        // analyticsComponent = GetComponent<SendToGoogle>();
        analyticsComponent = GameObject.Find("HUD").GetComponent<SendToGoogle>();
        respawnPoint = playerArmature.transform.position; 
        numberOfTimesSpawned = 1;
    }

    // Update is called once per frame
    void Update()
    {  
        HealthCheck();
    }

    public void HealthCheck(){
        if(currentHealth <= 0) {
            if(numberOfTimesSpawned <= 100) {
                FindObjectOfType<AudioManager>().play("death");
                Debug.Log("Respawning from health <= 0");
                Debug.Log(playerArmature.transform.position);
                respawn();
            }
            else {
                gameObject.SetActiveRecursively(false);
                if(gameOverCheck == false){
                analyticsComponent.Send(SceneManager.GetActiveScene().buildIndex.ToString(), "NA", "Died", "NA", "NA", "NA", "Health Over");
                runGameOverHud();
                // stop timer
                timer.pauseTimer();
                }
            }
        }
    }

    public void respawn() {
        Debug.Log("Respawn Function Entered!");
        Debug.Log(respawnPoint);
        playerArmature.transform.position = respawnPoint;
        Physics.SyncTransforms();
        currentHealth = maxHealth; 
        updateHealth(currentHealth);
        numberOfTimesSpawned = numberOfTimesSpawned + 1;
        Debug.Log("numberOfTimesSpawned");
        Debug.Log(numberOfTimesSpawned);
    }

    public static void setSpawnPoint(Vector3 spawnPoint) {
        Debug.Log("Setting Spawn Point");
        Debug.Log(spawnPoint);
        respawnPoint = spawnPoint;
        Debug.Log(respawnPoint);
    }

    public void runGameOverHud(){
        Debug.Log("Game over hud from health update!!");
        string msg = "You Died!";
        gameOverHUD.Setup(msg);
        gameOverCheck = true;
        // destroy the player
        // Destroy(gameObject);
    }

    public void OnCollisionEnter(Collision col) {
        // Debug.Log("Player got hit");
        if(col.gameObject.tag == "enemyBullet") {
            Destroy(col.gameObject);
            // Debug.Log("Enemy bullet destroyed!");
            Debug.Log(col.gameObject);
            currentHealth = currentHealth - 10;
            string msg = "HP - 10";
            player.ShowAlert(msg);
            updateHealth(currentHealth);
            StartCoroutine (waiter());
            return;            
        }
    }

    IEnumerator waiter(){
        yield return new WaitForSeconds(1);
        player.CloseAlert();
    }

    public void updateHealth(int health, int fall = 0) {
        // Debug.Log("Set health Called");
        // Debug.Log(health);
        healthBar.SetHealth(health);
         if(health == 0 && fall == 1) {
            // Debug.Log("Respawning because of falling down!");
            // Debug.Log(playerArmature.transform.position);
            respawn();
         }
        Debug.Log("Health set");
    }

    public int getNumberOfTimesSpawned() {
        return numberOfTimesSpawned;
    }

    public void changeCurrentHealth(int health){
        Debug.Log("Updated health ::: "+ health);
        currentHealth += health;
        updateHealth(health: currentHealth);
        Debug.Log("Current health ::: "+ currentHealth);
    }
    
}
