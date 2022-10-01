using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField] float turretRange = 13f;
    [SerializeField] int turretRotationOnDetectionSpeed = 30;
    [SerializeField] int turretShootRange = 7;
    [SerializeField] int fireRateConstant = 10;

   // private Transform playerTransform;  //could be changed to 'target' 
    private gun currentGun;
    private float fireRate;
    private float fireRateDelta;
    [SerializeField] GameObject player;
    public float distance;
    private Transform playerTarget; //* Variable to locate the player's body part we want to hit.

    private GameObject target;
    private RaycastHit hit;


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

        fireRateDelta -= fireRateConstant * Time.deltaTime;

        // if(fireRateDelta <= 0 && distance < turretShootRange)
        if(fireRateDelta <= 0 && distance < turretShootRange)
        {
            
            //* Rotate if the player is in range for the turret
            Quaternion rotation = Quaternion.LookRotation(playerDirection.normalized);
            Quaternion current = transform.localRotation;
            transform.localRotation = Quaternion.Slerp(current, rotation, Time.deltaTime * turretRotationOnDetectionSpeed * 1.3f);
            
            if (Physics.Raycast(currentGun.transform.position,playerDirection,out hit, turretRange)){

                if(hit.collider.gameObject.name == player.gameObject.name){
                    //* If enemy can see the player
                    rotation = Quaternion.LookRotation(playerDirection.normalized);
                    current = transform.localRotation;
                    transform.localRotation = Quaternion.Slerp(current, rotation, Time.deltaTime * turretRotationOnDetectionSpeed * 1.3f);
                    currentGun.Fire();
                    fireRateDelta = fireRate;
                }
            }
        }
       
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, turretRange);
    }
}