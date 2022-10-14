using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackViewCamera : MonoBehaviour
{
    public Transform target;
    [SerializeField] private float trailDistance = 10.0f;
    [SerializeField] private float heightOffset = 2.0f;
    [SerializeField] private float cameraDelay = 0.02f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 followPos = target.position - target.forward * trailDistance;   

        followPos.y += heightOffset;
        transform.position += (followPos - transform.position) * cameraDelay;
        transform.LookAt(target.transform);
    }
}
