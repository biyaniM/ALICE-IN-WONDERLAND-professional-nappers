using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGuideLaser : MonoBehaviour
{
    [SerializeField] private LineRenderer laserLineRenderer;
    [SerializeField] protected float laserWidth = 0.01f;
    [SerializeField] protected float laserMaxLength = 5f;
    private Transform chestTransform;
    // [SerializeField] protected Transform laserStartPointTransform;
    // Start is called before the first frame update
    void Start()
    {
        //* Initialize the linerenderer at zero position with the input width and length
        laserLineRenderer.SetPositions( new Vector3[2] {Vector3.zero, Vector3.zero});
        laserLineRenderer.startWidth = laserWidth;
        laserLineRenderer.endWidth = laserWidth;
        Debug.Log("Line is coming from "+gameObject);
        chestTransform = transform.parent.transform.Find("Skeleton/Hips/Spine/Chest/UpperChest");
    }

    // Update is called once per frame
    void Update()
    {
        ShootBulletGuideLaserFromTarget(chestTransform.position, transform.forward, laserMaxLength);
        laserLineRenderer.enabled = true;
    }

    void ShootBulletGuideLaserFromTarget( Vector3 targetPosition, Vector3 direction, float rayLength){
        Ray ray = new(targetPosition, direction);
        RaycastHit raycastHit, raycastHitBackward;
        Vector3 endPosition = targetPosition + (rayLength * direction);

        if (Physics.Raycast( ray, out raycastHit, rayLength)){
            Debug.Log("Laser Hitting "+raycastHit.collider.gameObject.name);
            // if (Physics.Raycast(new Ray(raycastHit.point, raycastHit.collider.transform.position-transform.position), out raycastHitBackward,rayLength)){
            //     Debug.Log("Hitting Back "+raycastHitBackward.collider.gameObject.name);
            // }
            if (!raycastHit.rigidbody){
                endPosition = raycastHit.point;
            }
        }

        //*Render the line
        laserLineRenderer.SetPosition(0, targetPosition);
        laserLineRenderer.SetPosition(1, endPosition);
    }
}
