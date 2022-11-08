using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoins : MonoBehaviour
{
    public Player player;
    public int redCoins; 
    public int blueCoins;
    public int yellowCoins;
    private int coinPointIncreaseOnCollection = 1;
    public int coinPointIncreaseOnEnemy = 1;
    public bool isTriggered = false;


    // Start is called before the first frame update
    void Start()
    {
            
    }

    public void OnTriggerEnter(Collider col){
        redCoins = player.GetRedCoinsScore();
        blueCoins = player.GetBlueCoinsScore();
        yellowCoins = player.GetYellowCoinsScore();
        // Debug.Log("Collect!" + redCoins + blueCoins + yellowCoins);
        if(col.gameObject.tag == "RedCoin"){
            Debug.Log("red Coin Collected!"); //TODO Add Collection Sound
            redCoins += coinPointIncreaseOnCollection;
            player.UpdateCoins(redCoins, blueCoins, yellowCoins);
            col.gameObject.SetActive(false);
            SendMsgToHUD("Red");
            
        }
        else if(col.gameObject.tag == "BlueCoin"){
            Debug.Log("blue Coin Collected!");
            blueCoins += coinPointIncreaseOnCollection;
            player.UpdateCoins(redCoins, blueCoins, yellowCoins);
            col.gameObject.SetActive(false);
            SendMsgToHUD("Blue");
        }
        else if(col.gameObject.tag == "YellowCoin"){
            Debug.Log("yellow Coin Collected!");
            yellowCoins += coinPointIncreaseOnCollection;
            player.UpdateCoins(redCoins, blueCoins, yellowCoins);
            col.gameObject.SetActive(false);
            SendMsgToHUD("Yellow");
            
        }
        else if(col.gameObject.tag == "BlueTutorialCoin"){
            Debug.Log("Coin Collected! Collect more color coins to finish the level!");
            blueCoins += coinPointIncreaseOnCollection;
            player.UpdateCoins(redCoins, blueCoins, yellowCoins);
            col.gameObject.SetActive(false);  
            SendMsgToHUD("Blue");
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
         //check if player has collected enough colors to pass gate
        player.CheckGoal(redCoins, blueCoins, yellowCoins);
    }

    public void updateGoldenCoin(int goldenCoinIncrement=0) 
    { //TODO Need to change this to only one coin increment (no blue, no red, no yellow). @sulysu
        redCoins = player.GetRedCoinsScore();
        blueCoins = player.GetBlueCoinsScore();
        yellowCoins = player.GetYellowCoinsScore();
        
        //* Increase golden coin amount to a custom value (pref higer than default). This helps make golden coin more useful.
        int coinIncrement = goldenCoinIncrement !=0 ? goldenCoinIncrement : coinPointIncreaseOnCollection;
        
        //* Update Coins
        redCoins += coinIncrement;
        blueCoins += coinIncrement;
        yellowCoins += coinIncrement;
        
        player.UpdateCoins(redCoins, blueCoins, yellowCoins);
        
    }
}
