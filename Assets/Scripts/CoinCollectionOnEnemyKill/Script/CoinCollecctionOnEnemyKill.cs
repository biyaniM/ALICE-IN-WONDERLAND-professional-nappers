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
    // Start is called before the first frame update
    void Start()
    {
        
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
                if (gameObject.tag=="enemy1"){
                    Debug.Log("Before Red Kill"+redCoins);
                    redCoins += 1;
                    Debug.Log("After Red Kill"+redCoins);
                }
                else if (gameObject.tag=="enemy2"){
                    // Debug.Log("Before Blue Kill"+redCoins);
                    blueCoins += 1;
                    // Debug.Log("After Red Kill"+redCoins);
                }
                else if (gameObject.tag=="enemy3"){
                    // Debug.Log("Before Red Kill"+redCoins);
                    yellowCoins += 1;
                    // Debug.Log("After Red Kill"+redCoins);
                }
                else{
                    return;
                }
            }
        }  
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("EnemyKillRED"+redCoins);
        player.UpdateCoins(redCoins, blueCoins, yellowCoins);
         //check if player has collected enough colors to pass gate
        player.CheckGoal(redCoins, blueCoins, yellowCoins);
    }
}
