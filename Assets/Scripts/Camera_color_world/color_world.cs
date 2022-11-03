using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class color_world : MonoBehaviour
{

    public Player player;
    public int redCoins; 
    public int blueCoins;
    public int yellowCoins;
    private int coinPointIncreaseOnCollection = 1;
    public int coinPointIncreaseOnEnemy = 1;
    public GameObject section_1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
            // SendMsgToHUD("Red");
            
        }
        else if(col.gameObject.tag == "BlueCoin"){
            Debug.Log("blue Coin Collected!");
            blueCoins += coinPointIncreaseOnCollection;
            player.UpdateCoins(redCoins, blueCoins, yellowCoins);
            col.gameObject.SetActive(false);
            // SendMsgToHUD("Blue");
        }
        else if(col.gameObject.tag == "YellowCoin"){
            Debug.Log("yellow Coin Collected!");
            yellowCoins += coinPointIncreaseOnCollection;
            player.UpdateCoins(redCoins, blueCoins, yellowCoins);
            col.gameObject.SetActive(false);
            // SendMsgToHUD("Yellow");
            
        }
        else if(col.gameObject.tag == "BlueTutorialCoin"){
            Debug.Log("remove section-1 component!!!");
            section_1 = GameObject.Find("sub_camera_1");
            section_1.gameObject.SetActive(false);
            // blueCoins += coinPointIncreaseOnCollection;
            // player.UpdateCoins(redCoins, blueCoins, yellowCoins);
            // col.gameObject.SetActive(false);  

            
            // SendMsgToHUD("Blue");
        }

    }
}
