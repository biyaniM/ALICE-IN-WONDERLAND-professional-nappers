using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoins : MonoBehaviour
{
    public Player player;
    [SerializeField] int totalCoins; 
    private int coinPointIncreaseOnCollection = 1;
    public bool isTriggered = false;


    // Start is called before the first frame update
    void Start()
    {
            
    }

    public void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "RedCoin" || col.gameObject.tag == "BlueCoin" || col.gameObject.tag == "YellowCoin" || col.gameObject.tag == "BlueTutorialCoin"){
            //TODO Add Collection Sound
            totalCoins += coinPointIncreaseOnCollection;
            player.UpdateCoins(totalCoins);
            col.gameObject.SetActive(false);
            SendMsgToHUD();
            
        }
    }

    void SendMsgToHUD(){
        string msg = "Gem +1";
        player.ShowAlert(msg);
        try {FindObjectOfType<AudioManager>().play("coin collect");}
        catch (System.NullReferenceException e) { Debug.LogWarning("Coin Collect sound not appointed in "+gameObject.scene+"\n"+e.ToString()); }
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
        player.CheckGoal(totalCoins);
    }

    public void updateGoldenCoin(int goldenCoinIncrement=0) 
    {
        totalCoins = player.GetCoinsScore();
        
        //* Increase golden coin amount to a custom value (pref higer than default). This helps make golden coin more useful.
        int coinIncrement = goldenCoinIncrement !=0 ? goldenCoinIncrement : coinPointIncreaseOnCollection;
        
        //* Update Coins
        totalCoins += coinIncrement;
        
        player.UpdateCoins(totalCoins);
    }
}
