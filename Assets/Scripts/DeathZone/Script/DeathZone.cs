using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{
    [SerializeField] GameOverHUD gameOverHUD;
    [SerializeField] CountDownTimer timer;
    public HealthBar healthBar;
    SendToGoogle analyticsComponent;
    void Start()
    {
        analyticsComponent = GameObject.Find("HUD").GetComponent<SendToGoogle>();
    }
    // Start is called before the first frame update
    void OnTriggerEnter(Collider collider){
        if (collider.tag == "Player"){
            //collider.gameObject.SetActive(false); //* Kill player by making inactive
            analyticsComponent.Send(SceneManager.GetActiveScene().buildIndex.ToString(), "NA", "Died", "NA", "NA", "NA", "Falling Down");
            healthBar.SetHealth(0); //* Make Health 0
            string msg = "You Died!";
            gameOverHUD.Setup(msg); //* Setup the gameover HUD
            timer.pauseTimer();
        }
    }
}
