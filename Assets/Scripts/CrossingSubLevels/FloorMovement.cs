using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMovement : MonoBehaviour
{
    public float speed = 2.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // transform.position = new Vector3(Mathf.PingPong(Time.time * speed, 8), transform.position.y, transform.position.z);
        // transformww.position = new Vector3(Mathf.PingPong(-1, 8), transform.position.y, transform.position.z);
    }
}
