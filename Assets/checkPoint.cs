using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPoint : MonoBehaviour
{

    public healthUpdate healthUpdateRef;
    // Start is called before the first frame update
    void Start()
    {
        healthUpdateRef = FindObjectOfType<healthUpdate>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider col) {
        if(col.gameObject.tag == "Player") {
            Debug.Log("Checkpoint crossed!");
            Vector3 newPosition = transform.position;
            healthUpdate.setSpawnPoint(newPosition);
        }
    }
}
