using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    [Header("Turret Settings")]
    [SerializeField] float turretRaycastRange = 13f;
    [SerializeField] int turretRotationSpeed = 50;
    [SerializeField] int turretShootRange = 7;
    [SerializeField] int fireRateConstant = 10;
    [SerializeField] float turrentRotationSpeedMultiplier = 1f;

   // private Transform playerTransform;  //could be changed to 'target' 
    protected gun currentGun;
    protected float fireRate;
    protected float fireRateDelta;
    [Header("Player Target GameObject")]
    [SerializeField] GameObject player;
    [Tooltip("Distance between Turret and Player")]
    public float distance;
    protected Transform playerTarget; //* Variable to locate the player's body part we want to hit.

    protected GameObject target;
    protected RaycastHit hit;


    protected void Start()
    {
        currentGun = GetComponentInChildren<gun>();
        fireRate = currentGun.GetRateOfFire();
        playerTarget = GetSkeletonPlayerTargetTransform(player);
    }

    protected Transform GetSkeletonPlayerTargetTransform(GameObject playerArmature, 
                string skeletonPart="Skeleton/Hips/Spine/Chest/UpperChest"){
        return playerArmature.transform.Find(skeletonPart);
    }

    protected void Update()
    {   
        Vector3 playerDirection = playerTarget.transform.position - transform.position;
        // //! playerGroundPos - transform.position is different from transform.position - playerGroundPos. This is because this is Vector subtraction, the direction will become opposite.
        distance = Vector3.Distance(playerTarget.transform.position, transform.position); 

        fireRateDelta -= fireRateConstant * Time.deltaTime;

        if(fireRateDelta <= 0 && distance < turretShootRange)
        {  
            if (Physics.Raycast(transform.position,playerDirection,out hit, turretRaycastRange)){
                //* Rotate if the player is in range for the turret
                if(hit.collider.gameObject.name == player.gameObject.name){
                    //* If enemy can see the player, then rotate
                    Debug.Log("WHAT?"+hit.collider.gameObject.name);
                    Quaternion rotation = Quaternion.LookRotation(playerDirection.normalized);
                    Quaternion current = transform.localRotation;
                    transform.localRotation = Quaternion.Slerp(current, rotation, Time.deltaTime * turretRotationSpeed * turrentRotationSpeedMultiplier);

                    if (Physics.Raycast(currentGun.gunPoint.forward,playerDirection,out hit, turretRaycastRange)){
                        //* Once the enemy can see the player and also is aiming towards it, then shoot
                        currentGun.Fire();
                        fireRateDelta = fireRate;
                    }
                }
            }
        }
       
    }

    protected void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, turretRaycastRange);
    }
}