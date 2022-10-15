using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoins : MonoBehaviour
{
    public Player player;
    public int redCoins; 
    public int blueCoins;
    public int yellowCoins;
    private int coinPointIncreaseOnCollection = 2;
    public int coinPointIncreaseOnEnemy = 2;
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
            Debug.Log("Coin Collected!"); //TODO Add Collection Sound
            redCoins += coinPointIncreaseOnCollection;
            player.UpdateCoins(redCoins, blueCoins, yellowCoins);
            //col.gameObject.SetActive(false);
            SendMsg("Red");
        }
        else if(col.gameObject.tag == "BlueCoin"){
            Debug.Log("Coin Collected!");
            blueCoins += coinPointIncreaseOnCollection;
            player.UpdateCoins(redCoins, blueCoins, yellowCoins);
            //col.gameObject.SetActive(false);
            SendMsg("Blue");
            
        }
        else if(col.gameObject.tag == "YellowCoin"){
            Debug.Log("Coin Collected!");
            yellowCoins += coinPointIncreaseOnCollection;
            player.UpdateCoins(redCoins, blueCoins, yellowCoins);
            //col.gameObject.SetActive(false);
            SendMsg("Yellow");
        }
        else if(col.gameObject.tag == "BlueTutorialCoin"){
            Debug.Log("Coin Collected! Collect more color coins to finish the level!");
            blueCoins += coinPointIncreaseOnCollection;
            player.UpdateCoins(redCoins, blueCoins, yellowCoins);
            //col.gameObject.SetActive(false);
            SendMsg("Blue");
        }
        
    }

    void SendMsg(string color){
        string msg = color + " Coin : + 1";
        player.ShowAlert(msg);
    }

    private void OnTriggerExit(Collider col) {
        switch (col.gameObject.tag){
            case "RedCoin":{
                player.CloseAlert();
                col.gameObject.SetActive(false);
                break;
            }
            case "BlueCoin":{
                player.CloseAlert();
                col.gameObject.SetActive(false);
                break;
            }            
            case "YellowCoin":{
                player.CloseAlert();
                col.gameObject.SetActive(false);
                break;
            }
            case "BlueTutorialCoin":{
                player.CloseAlert();
                col.gameObject.SetActive(false);
                break;
            }       
                
        }
    }

    // Update is called once per frame
    void Update()
    {
         //check if player has collected enough colors to pass gate
        player.CheckGoal(redCoins, blueCoins, yellowCoins);
    }
}
