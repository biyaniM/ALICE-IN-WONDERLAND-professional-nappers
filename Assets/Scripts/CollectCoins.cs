using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoins : MonoBehaviour
{
    public int redCoins; 
    public int blueCoins;
    public int yellowCoins;

    // Start is called before the first frame update
    void Start()
    {
            
    }

    public void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "RedCoin"){
            Debug.Log("Coin Collected!");
            redCoins = redCoins + 1;
            col.gameObject.SetActive(false);
        }
        else if(col.gameObject.tag == "BlueCoin"){
            Debug.Log("Coin Collected!");
            blueCoins = blueCoins + 1;
            col.gameObject.SetActive(false);
        }
        else if(col.gameObject.tag == "YellowCoin"){
            Debug.Log("Coin Collected!");
            yellowCoins = yellowCoins + 1;
            col.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
