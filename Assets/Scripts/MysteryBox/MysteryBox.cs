using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class MysteryBox : MonoBehaviour
{
    private enum mysteryBoxTypes {Health, Ammo, GoldenCoin};
    [SerializeField] private mysteryBoxTypes mysteryBoxType;
    [SerializeField] private int changeAmount;
    [SerializeField] private float hudAlertTime = 0.5f;
    private healthUpdate healthUpdateObj;
    private Player playerObj;
    private AmmoCount ammoCountObj;
    private CollectCoins coinCollectObj;
    private Coroutine coroutine;

    void Start()
    {
        GameObject hudObj = GameObject.Find("HUD");
        if (mysteryBoxType == mysteryBoxTypes.Health|| mysteryBoxType == mysteryBoxTypes.GoldenCoin){
            GameObject playerArmature = GameObject.FindGameObjectWithTag("Player");
            if(mysteryBoxType == mysteryBoxTypes.Health){
                healthUpdateObj = playerArmature.GetComponent<healthUpdate>();
            }
            else{
                coinCollectObj = playerArmature.GetComponent<CollectCoins>();
            }
        }else{
            ammoCountObj = hudObj.GetComponentInChildren<AmmoCount>();
        }
        playerObj = hudObj.GetComponent<Player>();
    }

    void Update()
    {
        
    }

    IEnumerator HealthReplenish(int healthIncerement){
        string msg = "HP +"+healthIncerement.ToString();
        playerObj.ShowAlert(msg);
        healthUpdateObj.currentHealth += healthIncerement;
        healthUpdateObj.updateHealth(Mathf.Min(healthUpdateObj.currentHealth,healthUpdateObj.maxHealth));
        yield return new WaitForSeconds(hudAlertTime);
        playerObj.CloseAlert();
    }

    IEnumerator AmmoReplenish(int ammoIncrement){
        string msg = "Ammo +"+ammoIncrement.ToString();
        playerObj.ShowAlert(msg);
        ammoCountObj.increaseAmmoCount(ammoIncrement);
        yield return new WaitForSeconds(hudAlertTime);
        playerObj.CloseAlert();
    }

    IEnumerator GoldenCoin(int coinIncrement){
        string msg = "Coins +"+coinIncrement.ToString();
        playerObj.ShowAlert(msg);
        coinCollectObj.updateGoldenCoin(coinIncrement);
        yield return new WaitForSeconds(hudAlertTime);
        playerObj.CloseAlert();
    }

    void OnTriggerEnter(Collider col){
        Debug.Log("Mystery Hit "+col);
        
        if (col.gameObject.tag=="Player"){
            Debug.Log("Mystery Good Job "+col);
            switch (mysteryBoxType){
                case mysteryBoxTypes.Health:
                    coroutine = StartCoroutine(HealthReplenish(changeAmount));
                    break;
                case mysteryBoxTypes.Ammo:
                    coroutine = StartCoroutine(AmmoReplenish(changeAmount));
                    break;
                case mysteryBoxTypes.GoldenCoin:
                    coroutine = StartCoroutine(GoldenCoin(changeAmount));
                    break;
            }
        }
        StopCoroutine(coroutine);
        Destroy(gameObject);
    }
}
