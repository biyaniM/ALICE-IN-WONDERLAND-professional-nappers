using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    CharacterController ch;

    // void Start() {
    //     ch = GetComponent<CharacterController>();
    // }

    // void update()
    // {
    //     float x = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
    //     float z = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
    //     ch.Move(new Vector3(x,0,z));
    // }
    private bool jumpKeyWasPressed;

    private float horizontalInput;

    private Rigidbody rigidbodyComponent;
    // Start is called before the first frame update
    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpKeyWasPressed = true;
        }

        horizontalInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate(){

        if (jumpKeyWasPressed){
            rigidbodyComponent.AddForce(Vector3.up * 5, ForceMode.VelocityChange);
            jumpKeyWasPressed = false;
        }

        rigidbodyComponent.velocity = new Vector3(horizontalInput, rigidbodyComponent.velocity.y, 1);
    }
}
