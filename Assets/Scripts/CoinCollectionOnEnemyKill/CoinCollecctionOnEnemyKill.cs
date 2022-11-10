using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollecctionOnEnemyKill : MonoBehaviour
{
    public Player player;
    private bool passed;
    public int timerIncrease = 6;
    protected CountDownTimer countDownTimer;
    
    // Start is called before the first frame update
    void Start()
    {
        countDownTimer = GameObject.Find("HUD").GetComponentInChildren<CountDownTimer>();
    }

    void Awake(){
        passed = false;
    }

    void OnTriggerEnter(Collider collider){
        if(!passed){
            if (collider.gameObject.name == "PaintBallProjectile(Clone)"){
                Debug.Log("Passed?"+passed);
                passed = true;
                Debug.Log("Hit!");

                if (gameObject.tag=="enemy_red"){
                    setNewTimeAfterKillingEnemy();
                }
                else if (gameObject.tag=="enemy_yellow"){
                    setNewTimeAfterKillingEnemy();
                }
                else if (gameObject.tag=="enemy_blue"){
                    setNewTimeAfterKillingEnemy();
                }
                else{
                    return;
                }
            }
        }  
    }

    void SendMsgToHUD(string color){
        string msg = color + " Coin +1";
        player.ShowAlert(msg);
        StartCoroutine (waiter());
    }

    IEnumerator waiter(){
        yield return new WaitForSeconds(1);
        player.CloseAlert();
    }
    // Update is called once per frame
    void Update()
    {        
        
    }

    public void setNewTimeAfterKillingEnemy() {
        int remainingDuration = countDownTimer.getRemainingDuration();
        int newDuration = remainingDuration + timerIncrease;
        countDownTimer.setRemainingDuration(newDuration);
    }
}
