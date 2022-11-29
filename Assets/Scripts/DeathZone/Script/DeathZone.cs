using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using StarterAssets;

public class DeathZone : MonoBehaviour
{
    [SerializeField] GameOverHUD gameOverHUD;
    [SerializeField] CountDownTimer timer;
    [Header("Health Decrement Settings")]
    public HealthBar healthBar;
    private healthUpdate healthUpdate;
    [Tooltip("If the Death Zone needs to kill the player instantly\nHealth Settings do not matter if Insta Kill is True")][SerializeField] private bool instaKill = false;
    [Tooltip("Health Decrement in each time interval")][SerializeField] private int healthDecrement = 10;
    [Tooltip("Time between each Health Decrement")][SerializeField] private int healthDecrementTimeInterval = 2;
    
    [Header("Player Movement Settings")]
    [Tooltip("Value by which the Movement Spped will be divided when in Death Zone")][SerializeField] float speedDivisionFactor = 1.5f;
    ThirdPersonController thirdPersonController;
    private float originalSpeed;
    [Header("Analytics Component")]SendToGoogle analyticsComponent;
    private Player playerObj;
    private Coroutine HealthDecrementCoroutine; 
    void Start()
    {
        analyticsComponent = GameObject.Find("HUD").GetComponent<SendToGoogle>();
        playerObj = GameObject.Find("HUD").GetComponent<Player>();
        GameObject playerArmature = GameObject.FindGameObjectWithTag("Player");
        thirdPersonController = playerArmature.GetComponent<ThirdPersonController>();
        healthUpdate = playerArmature.GetComponent<healthUpdate>();
        originalSpeed = thirdPersonController.MoveSpeed; //* Move Speed and Sprint Speed are same as Asserted in TPC
    }
    
    IEnumerator DeathZoneHealthDecrement(){
        while (healthUpdate.currentHealth > 0){
            string msg = "HP -"+healthDecrement.ToString();
            playerObj.ShowAlert(msg, "hp");

            //* Decrease Player Health
            healthUpdate.currentHealth -= healthDecrement;
            healthUpdate.updateHealth(healthUpdate.currentHealth, 1);

            try {FindObjectOfType<AudioManager>().play("player hurt");}
            catch (System.NullReferenceException e) { Debug.LogWarning("Coin Collect sound not appointed in "+gameObject.scene+"\n"+e.ToString()); }

            //* Wait for half time interval to close the HP decrease HUD
            yield return new WaitForSeconds(healthDecrementTimeInterval/2);

            playerObj.CloseAlert();

            //* Wait for half time interval until next HP Decrement 
            yield return new WaitForSeconds(healthDecrementTimeInterval/2);
        }
        Debug.Log("HHH"+healthUpdate.currentHealth);
    }

    private void DeathZoneInstaKill(){
        analyticsComponent.Send(SceneManager.GetActiveScene().buildIndex.ToString(), "NA", "Died", "NA", "NA", "NA", "Falling Down");
        healthBar.SetHealth(0); //* Make Health 0
        string msg = "You Died!";
        gameOverHUD.Setup(msg); //* Setup the gameover HUD
        playerObj.SetGameStatus(true);
        timer.pauseTimer();
    }
    
    void OnTriggerEnter(Collider collider){
        if (collider.tag == "Player"){
            //collider.gameObject.SetActive(false); //* Kill player by making inactive
            if (instaKill) {DeathZoneInstaKill();}
            else {
                thirdPersonController.MoveSpeed = thirdPersonController.SprintSpeed = originalSpeed / speedDivisionFactor; //* Make Player Slow
                HealthDecrementCoroutine = StartCoroutine(DeathZoneHealthDecrement());
            }      
        }
    }

    void OnTriggerExit(Collider collider){
        if (collider.tag == "Player"){
            if (!instaKill) {
                StopCoroutine(HealthDecrementCoroutine); //* Make Player Speed back to normal
                thirdPersonController.MoveSpeed = thirdPersonController.SprintSpeed = originalSpeed;
                playerObj.CloseAlert();
            }      
        }
    }
}
