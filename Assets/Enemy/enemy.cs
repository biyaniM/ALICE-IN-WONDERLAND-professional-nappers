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
    [SerializeField] float farAngleThreshold = 3f;
    [SerializeField] float closeAngleThreshold = 5f;
    [SerializeField] float closeAngleDistanceThreshold = 4f;

   // private Transform playerTransform;  //could be changed to 'target' 
    protected gun currentGun;
    protected float fireRate;
    protected float fireRateDelta;
    [Header("Player Target GameObject")]
    [SerializeField] GameObject player;
    [SerializeField] string playerArmatureSkeletonPartPath = "Skeleton/Hips"; 
    [Tooltip("Distance between Turret and Player")]
    public float distance;
    protected Transform playerTarget; //* Variable to locate the player's body part we want to hit.

    protected GameObject target;
    protected RaycastHit hit, hitFire;


    protected void Start()
    {
        currentGun = GetComponentInChildren<gun>();
        fireRate = currentGun.GetRateOfFire();
        playerTarget = GetSkeletonPlayerTargetTransform(player,playerArmatureSkeletonPartPath);
    }

    protected Transform GetSkeletonPlayerTargetTransform(GameObject playerArmature, 
                string skeletonPart="Skeleton/Hips/Spine/Chest/UpperChest"){
        return playerArmature.transform.Find(skeletonPart);
    }
    
    public void OnTriggerEnter(Collider col)
    {
        // Debug.WriteLine("Hello");
        
        if(col.transform.CompareTag("Player"))
        {
            col.transform.parent = null;
            Debug.Log("Hello");
        }
        
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
                
                if(hit.collider.gameObject == player.gameObject){
                    //* If the collider in sight is the player
                    
                    if(TargetInSight()){
                        //* If target is in sight, shoot!
                        currentGun.Fire();
                        fireRateDelta = fireRate;
                    }
                    else{
                        //* Rotate if the player is in range for the turret
                        RotateTurret(playerDirection);
                    }
                }
            }
        }
       
    }

    private void RotateTurret(Vector3 playerDirection){
        Quaternion rotation = Quaternion.LookRotation(playerDirection.normalized);
        Quaternion current = transform.localRotation;{
        transform.rotation = Quaternion.Slerp(current, rotation, Time.deltaTime * turretRotationSpeed * turrentRotationSpeedMultiplier);}
    }

    private bool TargetInSight(){
        Vector3 newDir = playerTarget.transform.position - currentGun.gunPoint.transform.position;
        
        if (Physics.Raycast(currentGun.gunPoint.transform.position, newDir, out hitFire, Mathf.Infinity)){
            //* If the Gun Point can see the player
            float angle = Vector3.Angle((playerTarget.transform.position - currentGun.gunPoint.transform.position), currentGun.gunPoint.transform.forward);
            
            float distanceBetween = Vector3.Distance(playerTarget.transform.position, currentGun.gunPoint.transform.position);
            if (angle<=farAngleThreshold){
                //* If enemy is far and angle is suitable to shoot, then target is in sight
                return true;
            }
            else if (distanceBetween <= closeAngleDistanceThreshold){
                //* If enemy is close then rotate. 
                RotateTurret(newDir);
                return true;
            }
            else if (angle <= closeAngleThreshold && distanceBetween <= closeAngleDistanceThreshold){ //TODO Remove redundant logic
                //* If enemy is close and angle is suitable to shoot, then target is in sight
                return true;
            }
        }
        return false;
    }

    protected void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, turretRaycastRange);
    }
}