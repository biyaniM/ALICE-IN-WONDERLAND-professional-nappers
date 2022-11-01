using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] float rateOfFire = 15f;
    [SerializeField] public Transform gunPoint;    

    private void Start()
    {

    }

    public float GetRateOfFire()
    {
        return rateOfFire;   
    }

    public void Fire()
    {
        Instantiate(projectile.transform, gunPoint.position, gunPoint.rotation);   
        // Instantiate(projectile, gunPoint.position, transform.rotation);  
    }
}