using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] float rateOfFire = 15f;
    [SerializeField] Transform gunPoint;  
    public float projectileSpeed = 5f;  
    public Transform spawnPoint;
    public GameObject bullet;

    private void Start()
    {

    }

    private void Update()   //you can change this to a virtual function for multiple projectile types
    {
        // if(Input.GetButtonDown("Fire1"))
        //     ShootBullet();
        // transform.Translate(new Vector3(0f, 0f, projectileSpeed * Time.deltaTime));
        ShootBullet();
    }
    


    public float GetRateOfFire()
    {
        return rateOfFire;   
    }

    public void Fire()
    {
        Instantiate(projectile, gunPoint.position, transform.rotation);   
        Instantiate(projectile, gunPoint.position, transform.rotation);  
    }
    private void ShootBullet()
    {
        GameObject cb = Instantiate(bullet, spawnPoint.position, bullet.transform.rotation);
        Rigidbody rig = cb.GetComponent<Rigidbody>();
        rig.AddForce(spawnPoint.forward * projectileSpeed, ForceMode.Impulse);
    }

}