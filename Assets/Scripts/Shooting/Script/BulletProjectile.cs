using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour
{
    // Update is called once per frame
    private Rigidbody bulletRigidbody;
    public float bulletSpeed = 30f;
    public float bulletLifeSpan = 0.3f;
    
    private void Awake(){
        bulletRigidbody = GetComponent<Rigidbody>();
    }
    private void Start(){
        // bulletRigidbody.AddForce(bulletRigidbody.transform.forward * bulletSpeed);
        bulletRigidbody.velocity = bulletRigidbody.transform.forward * bulletSpeed;
        Destroy(gameObject, bulletLifeSpan);
    }

    private void OnCollisionEnter(Collision collision){
        if (collision.collider.GetComponent<BulletTarget>() !=null){
            Debug.Log("Hit Target!");
        }else{
            Debug.Log("Not Hit target");
        }
        Destroy(gameObject);
    }

    // private void OnTriggerEnter(Collider other){
        
}