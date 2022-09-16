using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_test : MonoBehaviour
{
    public float speed = 5.0f;
    private float horizontalInput;
    private float forwardInput;
    
    // Start is called before the first frame update
    void Start()
    {

        Debug.Log("Started!!!!!");
        Debug.Log(horizontalInput);
    }

    // Update is called once per frame
    void Update()
    {    
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

    }
}