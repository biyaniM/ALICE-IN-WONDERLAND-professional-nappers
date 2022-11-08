using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoins : MonoBehaviour
{
    public Player player;
    //public int redCoins; 
    //public int blueCoins;
    //public int yellowCoins;
    [SerializeField] int totalCoins; 
    private int coinPointIncreaseOnCollection = 1;
    public bool isTriggered = false;


    // Start is called before the first frame update
    void Start()
    {
            
    }

    public void OnTriggerEnter(Collider col){
        //redCoins = player.GetRedCoinsScore();
        //blueCoins = player.GetBlueCoinsScore();
        //yellowCoins = player.GetYellowCoinsScore();
        if(col.gameObject.tag == "RedCoin" || col.gameObject.tag == "BlueCoin" || col.gameObject.tag == "YellowCoin" || col.gameObject.tag == "BlueTutorialCoin"){
            //TODO Add Collection Sound
            totalCoins += coinPointIncreaseOnCollection;
            //player.UpdateCoins(redCoins, blueCoins, yellowCoins);
            player.UpdateCoins(totalCoins);
            col.gameObject.SetActive(false);
            SendMsgToHUD();
            
        }
        // else if(col.gameObject.tag == "BlueCoin"){
        //     Debug.Log("blue Coin Collected!");
        //     blueCoins += coinPointIncreaseOnCollection;
        //     player.UpdateCoins(redCoins, blueCoins, yellowCoins);
        //     col.gameObject.SetActive(false);
        //     SendMsgToHUD("Blue");
        // }
        // else if(col.gameObject.tag == "YellowCoin"){
        //     Debug.Log("yellow Coin Collected!");
        //     yellowCoins += coinPointIncreaseOnCollection;
        //     player.UpdateCoins(redCoins, blueCoins, yellowCoins);
        //     col.gameObject.SetActive(false);
        //     SendMsgToHUD("Yellow");
            
        // }
        // else if(col.gameObject.tag == "BlueTutorialCoin"){
        //     Debug.Log("Coin Collected! Collect more color coins to finish the level!");
        //     blueCoins += coinPointIncreaseOnCollection;
        //     player.UpdateCoins(redCoins, blueCoins, yellowCoins);
        //     col.gameObject.SetActive(false);  
        //     SendMsgToHUD("Blue");
        // }

    }

    void SendMsgToHUD(){
        string msg = "Coin +1";
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
        //player.CheckGoal(redCoins, blueCoins, yellowCoins);
        player.CheckGoal(totalCoins);
    }

    public void updateGoldenCoin(int goldenCoinIncrement=0) 
    { //TODO Need to change this to only one coin increment (no blue, no red, no yellow). @sulysu
        //redCoins = player.GetRedCoinsScore();
        //blueCoins = player.GetBlueCoinsScore();
        //yellowCoins = player.GetYellowCoinsScore();
        totalCoins = player.GetCoinsScore();
        
        //* Increase golden coin amount to a custom value (pref higer than default). This helps make golden coin more useful.
        int coinIncrement = goldenCoinIncrement !=0 ? goldenCoinIncrement : coinPointIncreaseOnCollection;
        
        //* Update Coins
        //redCoins += coinIncrement;
        //blueCoins += coinIncrement;
        //yellowCoins += coinIncrement;
        totalCoins += coinIncrement;
        
        //player.UpdateCoins(redCoins, blueCoins, yellowCoins);
        player.UpdateCoins(totalCoins);
    }
}
