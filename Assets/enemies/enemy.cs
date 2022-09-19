using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField] float turretRange = 13f;
    [SerializeField] float turretRotationSpeed = 0.05f;

   // private Transform playerTransform;  //could be changed to 'target' 
    private gun currentGun;
    private float fireRate;
    private float fireRateDelta;
    [SerializeField] GameObject player;
    public float distance;

    private GameObject target;


    private void Start()
    {
        currentGun = GetComponentInChildren<gun>();
        fireRate = currentGun.GetRateOfFire();
    }

    private void Update()
    {   
        float turretRotationStep = turretRotationSpeed * Time.deltaTime;
        // Vector3 playerGroundPos = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        // Vector3 playerDirection = playerGroundPos - transform.position;
        // Vector3 newLookDirection = Vector3.RotateTowards(transform.forward, playerDirection,
        // turretRotationStep, 0f);
        // transform.rotation = Quaternion.LookRotation(newLookDirection);

        distance = Vector3.Distance(transform.position, player.transform.position);
        transform.Rotate(new Vector3(0f,0.3f,0f));
        fireRateDelta -= 10*Time.deltaTime;

        if(fireRateDelta <= 0 && distance < 5)
        {
            currentGun.Fire();
            currentGun.Fire();
            currentGun.Fire();
            fireRateDelta = fireRate;
        }
       
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, turretRange);
    }
}