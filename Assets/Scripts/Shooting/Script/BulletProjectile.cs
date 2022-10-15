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
    public Player player;


    private void Awake(){
        bulletRigidbody = GetComponent<Rigidbody>();
    }
    private void Start(){
        //bulletRigidbody.AddForce(bulletRigidbody.transform.forward * bulletSpeed);
        player = GameObject.Find("HUD").GetComponent<Player>();
        bulletRigidbody.velocity = bulletRigidbody.transform.forward * bulletSpeed;
        Destroy(gameObject, bulletLifeSpan);
    }

    private void OnCollisionEnter(Collision col){
         switch (col.gameObject.tag){
            case "enemy_red":{  
                player.UpdateNumberOfKill();
                SendMsg("Red");
                break;
            }
            case "enemy_yellow":{
                player.UpdateNumberOfKill();
                SendMsg("Yellow");
                break;
            }
            case "enemy_blue":{
                player.UpdateNumberOfKill();
                SendMsg("Blue");
                break;
            }

         }
    }

    private void OnCollisionExit(Collision col) {
        Destroy(gameObject);

        if(col.gameObject.tag == "enemy_red" || col.gameObject.tag == "enemy_yellow" || col.gameObject.tag == "enemy_blue"){
            Destroy(col.gameObject);
            //improvement: delay for 1s and closealert
            player.CloseAlert();
        }
    }

    void SendMsg(string color){
        const string alertTemplate = "Killed {0} Enemy: + 1 {0} Coin";
        var msg = string.Format(alertTemplate, color);
        player.ShowAlert(msg);
    }


        
}