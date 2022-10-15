using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    [SerializeField] GameOverHUD gameOverHUD;
    [SerializeField] CountDownTimer timer;
    public HealthBar healthBar;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider collider){
        if (collider.tag == "Player"){
            collider.gameObject.SetActive(false); //* Kill player by making inactive
            healthBar.SetHealth(0); //* Make Health 0
            gameOverHUD.Setup(); //* Setup the gameover HUD
            timer.pauseTimer();
        }
    }
}
