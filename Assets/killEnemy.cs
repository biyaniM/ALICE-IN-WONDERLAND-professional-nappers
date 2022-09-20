using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killEnemy : MonoBehaviour
{  
    public int enemy1Hits = 0;
    public int enemy2Hits = 0;
    public int enemy3Hits = 0;


    void Start()
    {

    }

    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider col) {
        Debug.Log("Got here!");
        if(col.gameObject.tag == "enemy1"){
            if(enemy1Hits >= 1) {  // Will change this value later when health system is integrated
                Debug.Log("Enemy 1 Killed!");
                Destroy(col.gameObject);
            }
            else {
                enemy1Hits = enemy1Hits + 1;
            }
        }
        if(col.gameObject.tag == "enemy2"){
            if(enemy2Hits >= 3) {  // Will change this value later when health system is integrated
                Debug.Log("Enemy 2 Killed!");
                Destroy(col.gameObject);
            }
            else {
                enemy2Hits = enemy2Hits + 1;
            }
        }
        if(col.gameObject.tag == "enemy3"){
            if(enemy3Hits >= 3) { // Will change this value later when health system is integrated
                Debug.Log("Enemy 3 Killed!");
                Destroy(col.gameObject);
            }
            else {
                enemy3Hits = enemy3Hits + 1;
            }
        }

    }
}

