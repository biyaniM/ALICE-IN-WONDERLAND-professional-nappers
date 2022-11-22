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

        try {FindObjectOfType<AudioManager>().play("enemy shot");}
        catch (System.NullReferenceException e) { Debug.LogWarning("Enemy Shot sound not appointed in "+gameObject.scene+"\n"+e.ToString()); }

        Instantiate(projectile.transform, gunPoint.position, gunPoint.rotation);     
    }
}