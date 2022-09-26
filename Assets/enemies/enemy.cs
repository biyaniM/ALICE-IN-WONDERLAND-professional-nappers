using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField] float turretRange = 13f;
    [SerializeField] int turretRotationOnDetectionSpeed = 10;
    [SerializeField] float angleThreshold = 15.0f;
    [SerializeField] int turretShootRange = 7;

   // private Transform playerTransform;  //could be changed to 'target' 
    private gun currentGun;
    private float fireRate;
    private float fireRateDelta;
    [SerializeField] GameObject player;
    public float distance;
    private Transform playerTarget; //* Variable to locate the player's body part we want to hit.

    private GameObject target;


    private void Start()
    {
        currentGun = GetComponentInChildren<gun>();
        fireRate = currentGun.GetRateOfFire();
        playerTarget = GetSkeletonPlayerTargetTransform(player);
    }

    private Transform GetSkeletonPlayerTargetTransform(GameObject playerArmature, 
                string skeletonPart="Skeleton/Hips/Spine/Chest/UpperChest"){
        return playerArmature.transform.Find(skeletonPart);
    }

    private void Update()
    {   
        Vector3 playerDirection = playerTarget.transform.position - transform.position;
        // //! playerGroundPos - transform.position is different from transform.position - playerGroundPos. This is because this is Vector subtraction, the direction will become opposite.
        distance = Vector3.Distance(playerTarget.transform.position, transform.position); 

        fireRateDelta -= 25 * Time.deltaTime;

        if(fireRateDelta <= 0 && distance < turretShootRange)
        {
            //* Rotate if the player is in range for the turret
            Quaternion rotation = Quaternion.LookRotation(playerDirection);
            Quaternion current = transform.localRotation;
            transform.localRotation = Quaternion.Slerp(current, rotation, Time.deltaTime * turretRotationOnDetectionSpeed);
            
            //* Angle function checks the angle between the players position vector and enemy's position vector
            if (180-Vector3.Angle(currentGun.transform.forward,playerTarget.transform.position)<=angleThreshold){
                //* If the enemy is in a certain angle threshold, only then shoot
                currentGun.Fire();
                fireRateDelta = fireRate;
            } 
        }
       
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, turretRange);
    }
}