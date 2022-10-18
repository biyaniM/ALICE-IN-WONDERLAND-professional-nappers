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

    public int maxHealth = 100;
    public int currentHealth = 100;
    // Start is called before the first frame update
    void Start()
    {  
        gameOverCheck = false;       
        player = GameObject.Find("HUD").GetComponent<Player>();
        // analyticsComponent = GetComponent<SendToGoogle>();
        analyticsComponent = GameObject.Find("HUD").GetComponent<SendToGoogle>();
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
                analyticsComponent.Send(SceneManager.GetActiveScene().buildIndex.ToString(), "NA", "Died", "NA", "NA", "NA", "Health Over");
                runGameOverHud();
                // stop timer
                timer.pauseTimer();
            }
        }
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
        Debug.Log("Player got hit");
        if(col.gameObject.tag == "enemyBullet") {
            Destroy(col.gameObject);
            Debug.Log("Enemy bullet destroyed!");
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
