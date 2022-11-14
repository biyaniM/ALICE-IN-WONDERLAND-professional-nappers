using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour
{
    // Update is called once per frame
    private Rigidbody bulletRigidbody;
    public GameObject bullet;
    public Transform spawnPoint;
    public float bulletSpeed = 30f;
    public float bulletLifeSpan = 0.3f;
    [SerializeField] float projectileSpeed = 15f;
    // public float projectileSpeed = 5f;
    // public Transform attackPoint;
    // public float shootForce, upwardForce;
    // public float spread;
    // public GameObject bullet;
    // public Camera fpsCam;
    private Player player;


    private void Awake(){
        bulletRigidbody = GetComponent<Rigidbody>();
    }
    private void Start(){
        //bulletRigidbody.AddForce(bulletRigidbody.transform.forward * bulletSpeed);
        bulletRigidbody.velocity = bulletRigidbody.transform.forward * bulletSpeed;
        Destroy(gameObject, bulletLifeSpan);
    }

    private void OnCollisionEnter(Collision col){
        /*if (col.GetComponent<BulletTarget>() !=null){
             Debug.Log("Hit Target!");
        }else{
            Debug.Log("Not Hit target");
        }*/
        if (col.gameObject.tag!="Player"){Destroy(gameObject);}

        if(col.gameObject.tag == "enemy_red" || col.gameObject.tag == "enemy_yellow" || col.gameObject.tag == "enemy_blue"){
            Debug.Log("Killed Enemy!!!!!");
            player = GameObject.Find("HUD").GetComponent<Player>();
            player.UpdateNumberOfKill();
            //Debug.Log("Number of Enemy Kill:" + player.GetNumberOfKill());
        }
    }
        
}