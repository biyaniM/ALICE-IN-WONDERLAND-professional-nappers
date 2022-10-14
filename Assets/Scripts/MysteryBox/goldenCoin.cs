using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goldenCoin : MonoBehaviour
{
    [SerializeField] private int boxDestroy = 3;
    public CollectCoins goldCoin;
    
    // Start is called before the first frame update

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void allCoinCollection()
    {
        goldCoin.updateGoldenCoin();
    }
    public void OnCollisionEnter(Collision col){
        if(col.gameObject.tag == "playerBullet"){
            Destroy(col.gameObject);
            boxDestroy = boxDestroy - 1;
            if(boxDestroy <= 0){
                Destroy(this.gameObject);
            }
            if(boxDestroy==0)
            {
                allCoinCollection();
            }
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
