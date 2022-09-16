using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] float rateOfFire = 15f;
    [SerializeField] Transform gunPoint;    //This is optional. Watch the video fore more information.


    private void Start()
    {
        // if(gunPoint == null)
        //     gunPoint = GetComponentInChildren<gunPoint>().transform;
    }
    public float GetRateOfFire()
    {
        return rateOfFire;   
    }

    public void Fire()
    {
        Instantiate(projectile, gunPoint.position, transform.rotation);   
        //Instantiate(projectile, gunPoint.position, transform.rotation);   
                    //you can use transform.position instead of gunPoint.position
                    //if this script is attached directly to a gunpoint
    }
}