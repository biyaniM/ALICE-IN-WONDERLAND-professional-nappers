using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollecctionOnEnemyKill : MonoBehaviour
{
    public Player player;
    public int redCoins; 
    public int blueCoins;
    public int yellowCoins;
    private bool passed;
    public int timerIncrease = 6;
    protected CountDownTimer countDownTimer;
    
    // Start is called before the first frame update
    void Start()
    {
        countDownTimer = GameObject.Find("HUD").GetComponentInChildren<CountDownTimer>();
    }

    void Awake(){
        // redCoins = int.Parse(player.coinsScore.redScore.text);
        // blueCoins = int.Parse(player.coinsScore.blueScore.text);
         // yellowCoins = int.Parse(player.coinsScore.yellowScore.text);
        passed = false;
    }

    void OnTriggerEnter(Collider collider){
        if(!passed){
            if (collider.gameObject.name == "PaintBallProjectile(Clone)"){
                Debug.Log("Passed?"+passed);
                passed = true;
                Debug.Log("Hit!");
                redCoins = player.GetRedCoinsScore();
                blueCoins = player.GetBlueCoinsScore();
                yellowCoins = player.GetYellowCoinsScore();

                if (gameObject.tag == "enemy_red" || gameObject.tag=="enemy_yellow" || gameObject.tag=="enemy_blue"){
                    setNewTimeAfterKillingEnemy();
                    SendMsgToHUD("+ "+timerIncrease.ToString()+" Seconds");
                }else{
                    return;
                }
                
                Destroy(gameObject);
            }
        }
    }

    void SendMsgToHUD(string msg){
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
         //check if player has collected enough colors to pass gate
        player.CheckGoal(redCoins, blueCoins, yellowCoins);
    }

    public void setNewTimeAfterKillingEnemy() {
        int remainingDuration = countDownTimer.getRemainingDuration();
        int newDuration = remainingDuration + timerIncrease;
        countDownTimer.setRemainingDuration(newDuration);
    }
}
