//! Redundant Code
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBox : MonoBehaviour
{
    public healthUpdate healthUpdate; 
    [SerializeField] private int boxDestroy = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void updateHealth(int health){
        healthUpdate.changeCurrentHealth(health);
    }
    
    

    public void OnCollisionEnter(Collision col){
        if(col.gameObject.tag == "playerBullet"){
            Destroy(col.gameObject);
            boxDestroy = boxDestroy - 1;
            if(boxDestroy <= 0){
                Destroy(this.gameObject);
            }
            
        }
        if(boxDestroy == 0){
            updateHealth(10);
        }
        return;
    }
    
}