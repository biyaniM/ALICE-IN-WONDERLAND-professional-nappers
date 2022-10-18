using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class UpDown : MonoBehaviour
{
    public float speed = 5f;
    public float movementMultiplier = 3f;
    private float original;
    private List<char> movementAxisSelectionOptions = new List<char> {'X','Y','Z','x','y','z'};
    public char movementAxis;
    [SerializeField] private GameObject player;
    [SerializeField] private int height_x;
    [SerializeField] private int height_y;
    [SerializeField] private int height_z;
    // Start is called before the first frame update
    void Start()
    {
        Assert.IsTrue(movementAxisSelectionOptions.Contains(movementAxis));
        if (movementAxis == 'Z' || movementAxis == 'z'){
            original = transform.position.z;
        }
        else if (movementAxis == 'X' || movementAxis == 'x'){
            original = transform.position.x;
        }
        else{
            original = transform.position.y;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (movementAxis == 'Z' || movementAxis == 'z'){
            // float zVal = original + movementMultiplier * Mathf.Sin(Mathf.PingPong(Time.time, 2* Mathf.PI));
            float zVal = original + (Mathf.PingPong(Time.time * speed, height_z));
            transform.position = new Vector3(transform.position.x, transform.position.y , zVal);
        }
        else if (movementAxis == 'X' || movementAxis == 'x'){
            float xVal = original + (Mathf.PingPong(Time.time * speed, height_x));
            // float xVal = original + movementMultiplier * Mathf.Sin(Mathf.PingPong(Time.time, 2* Mathf.PI));
            // transform.position = new Vector3(xVal, transform.position.y , transform.position.z);
        }
        else{
            float yVal = original + (Mathf.PingPong(Time.time * speed, height_y));
            transform.position = new Vector3(transform.position.x, yVal , transform.position.z);
        }
    }

    private void OnTriggerEnter(Collider collider){
        Debug.Log(gameObject +" collides with " +collider.gameObject);
        if (collider.gameObject == player){
            // player.transform.parent = transform;
            collider.transform.SetParent(transform, true);
            Debug.Log("Changed Parent to "+player.transform.parent.gameObject);
        }
    }

    private void OnTriggerExit(Collider collider){
        if (collider.gameObject == player){
            collider.transform.parent = null;
        }
    }
}
