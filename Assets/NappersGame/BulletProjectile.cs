using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour
{
    // Update is called once per frame
    private Rigidbody bulletRigidbody;

    private void Awake(){
        bulletRigidbody = GetComponent<Rigidbody>();
    }
    private void Start(){
        float speed = 50f;
        bulletRigidbody.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other){
        Destroy(bulletRigidbody);
    }
}
