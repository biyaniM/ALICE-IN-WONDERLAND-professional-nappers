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

    
    private void Awake(){
        bulletRigidbody = GetComponent<Rigidbody>();
    }
    private void Start(){
        //bulletRigidbody.AddForce(bulletRigidbody.transform.forward * bulletSpeed);
        bulletRigidbody.velocity = bulletRigidbody.transform.forward * bulletSpeed;
        Destroy(gameObject, bulletLifeSpan);
    }

    private void OnCollisionEnter(Collision collision){
        if (collision.collider.GetComponent<BulletTarget>() !=null){
             Debug.Log("Hit Target!");
        }else{
            Debug.Log("Not Hit target");
        }
        // Destroy(gameObject);
    }
    // private void Update()   //you can change this to a virtual function for multiple projectile types
    // {
    //     if(Input.GetButtonDown("Fire1"))
    //         ShootBullet();
    //     // transform.Translate(new Vector3(0f, 0f, projectileSpeed * Time.deltaTime));
    // }

    // private void ShootBullet()
    // {
    //     GameObject cb = Instantiate(bullet, spawnPoint.position, bullet.transform.rotation);
    //     Rigidbody rig = cb.GetComponent<Rigidbody>();
    //     rig.AddForce(spawnPoint.forward * projectileSpeed, ForceMode.Impulse);
    // }

    // private void Shoot()
    // {
    //     Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); //Just a ray through the middle of your current view
    //     RaycastHit hit;
    //     //check if ray hits something
    //     Vector3 targetPoint;
    //     if (Physics.Raycast(ray, out hit))
    //         targetPoint = hit.point;
    //     else
    //         targetPoint = ray.GetPoint(75); //Just a point far away from the player
    //     Vector3 directionWithoutSpread = targetPoint - attackPoint.position;
    //         //Calculate spread
    //     float x = Random.Range(-spread, spread);
    //     float y = Random.Range(-spread, spread);

    //     Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, 0); //Just add spread to last direction
    //     GameObject currentBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity); //store instantiated bullet in currentBullet
    //     //Rotate bullet to shoot direction
    //     currentBullet.transform.forward = directionWithSpread.normalized;
    //     currentBullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * shootForce, ForceMode.Impulse);
    // }
    // private void OnTriggerEnter(Collider other){
        
}