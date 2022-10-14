using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float angle = 10f;
    public float roatationSpeed = 0.15f;

    void Start(){
        // transform.childCount
    }
    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.position, Vector3.up, angle * roatationSpeed);
    }

    void OnTriggerEnter(Collider collider){
        if (collider.tag == "Player"){
            collider.transform.SetParent(transform, true);
        }
    }
    void OnTriggerExit(Collider collider){
        if (collider.tag == "Player"){
            collider.transform.parent = null;
        }
    }
}
