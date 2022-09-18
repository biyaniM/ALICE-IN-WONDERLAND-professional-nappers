using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoins : MonoBehaviour
{
    public Player player;
    public int redCoins; 
    public int blueCoins;
    public int yellowCoins;
    public int coinPointIncreaseOnCollection = 2;
    public int coinPointIncreaseOnEnemy = 1;

    // Start is called before the first frame update
    void Start()
    {
            
    }

    public void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "RedCoin"){
            Debug.Log("Coin Collected!"); //TODO Add Collection Sound
            redCoins += coinPointIncreaseOnCollection;
            col.gameObject.SetActive(false);
        }
        else if(col.gameObject.tag == "BlueCoin"){
            Debug.Log("Coin Collected!");
            blueCoins += coinPointIncreaseOnCollection;
            col.gameObject.SetActive(false);
        }
        else if(col.gameObject.tag == "YellowCoin"){
            Debug.Log("Coin Collected!");
            yellowCoins += coinPointIncreaseOnCollection;
            col.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //update coins status to HUD
        player.UpdateCoins(redCoins, blueCoins, yellowCoins);
         //check if player has collected enough colors to pass gate
        player.CheckGoal(redCoins, blueCoins, yellowCoins);
    }
}
