using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollecctionOnEnemyKill : MonoBehaviour
{
    public Player player;
    private bool passed;
    public int timerIncrease = 6;
    protected CountDownTimer countDownTimer;
    protected ParticleSystem explosion;
    
    // Start is called before the first frame update
    void Start()
    {
        countDownTimer = GameObject.Find("HUD").GetComponentInChildren<CountDownTimer>();
    }

    void Awake(){
        passed = false;
    }

    void OnTriggerEnter(Collider collider){
        Debug.Log("HIT");
        if(!passed){

            if (collider.gameObject.name == "PaintBallProjectile(Clone)"){
                passed = true;

                if (gameObject.tag == "enemy_red" || gameObject.tag=="enemy_yellow" || gameObject.tag=="enemy_blue"){
                    setNewTimeAfterKillingEnemy();
                    SendMsgToHUD("+ "+timerIncrease.ToString()+" Seconds");
                }else{
                    return;
                }

                //* Explosion
                try {
                    explosion = transform.parent.Find("Explosion").GetComponent<ParticleSystem>();
                    if (explosion!= null) explosion.Play();
                }catch (System.NullReferenceException e){
                    Debug.LogException(e, this);
                    Debug.Log("Please Provide Explosion Game Object");
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

    }

    public void setNewTimeAfterKillingEnemy() {
        int remainingDuration = countDownTimer.getRemainingDuration();
        int newDuration = remainingDuration + timerIncrease;
        countDownTimer.setRemainingDuration(newDuration);
    }
}
