using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] float rateOfFire = 15f;
    [SerializeField] public Transform gunPoint;
    private ParticleSystem shootFlash;  

    private void Start()
    {
        shootFlash = GetComponentInChildren<ParticleSystem>();
    }

    public float GetRateOfFire()
    {
        return rateOfFire;   
    }

    public void Fire()
    {
        if (shootFlash != null){
        shootFlash.Play();
        }
        Instantiate(projectile.transform, gunPoint.position, gunPoint.rotation);     
    }
}