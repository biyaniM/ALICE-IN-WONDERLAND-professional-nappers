using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour
{
    [SerializeField] float turretRange = 0.0002f;
    [SerializeField] float turretRotationSpeed = 0.05f;

    private Transform playerTransform;  //could be changed to 'target' 
    private gun currentGun;
    private float fireRate;
    private float fireRateDelta;
    public GameObject player;

    private void Start()
    {
       playerTransform = player.transform;
       Debug.Log(playerTransform);
        // playerTransform = FindObjectOfType<PlayerArmature>().transform;   
                        //could replace this with a public function that sets target
                        //On Trigger Enter if there is multiple targets
        currentGun = GetComponentInChildren<gun>();
        fireRate = currentGun.GetRateOfFire();
    }

    private void Update()
    {
        Vector3 playerGroundPos = new Vector3(playerTransform.position.x, 
                                  transform.position.y, playerTransform.position.z);
        Debug.Log("Player ground pos====");
        Debug.Log(playerGroundPos);
        Debug.Log(Vector3.Distance(transform.position, playerGroundPos));

        //Check if player is not in range, then do nothing
        if(Vector3.Distance(transform.position, playerGroundPos) > turretRange)
        {
            
            return; //do nothing because player is not in range
        }

        // PLAYER IN RANGE

        // Rotate Turret towards player
       Vector3 playerDirection = playerGroundPos - transform.position;
      //  transform.Rotate(new Vector3(0f,0.3f,0f));
        float turretRotationStep = turretRotationSpeed * Time.deltaTime;
        Vector3 newLookDirection = Vector3.RotateTowards(transform.forward, playerDirection,
                                  turretRotationStep, 0f);
       transform.rotation = Quaternion.LookRotation(newLookDirection);

        fireRateDelta -= 2*Time.deltaTime;
        if(fireRateDelta <= 0 && Vector3.Distance(transform.position, playerGroundPos) < turretRange)
        {
            currentGun.Fire();
            currentGun.Fire();
            currentGun.Fire();
            fireRateDelta = fireRate;
       }
       
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, turretRange); //Show a gizmo when selected
    }

    // private void OnCollisionEnter(Collision collision) {
    //     if(collision.transform.tag== "Enemy ")
    //     {
    //         Destroy(collision.gameObject);
    //         gameObject.SetActive(false);
    //     }
    // }
}