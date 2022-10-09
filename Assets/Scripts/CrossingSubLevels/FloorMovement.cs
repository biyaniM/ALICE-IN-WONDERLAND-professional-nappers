using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class FloorMovement : MonoBehaviour
{
    public float speed = 5f;
    public float movementMultiplier = 3f;
    private float original_x;
    private float original_z;
    private float original_y;
    private List<string> movementAxisSelectionOptions = new List<string> {"XZ","Y","ZX","xz", "y","zx"};
    public string movementAxis;
    [SerializeField] private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        Assert.IsTrue(movementAxisSelectionOptions.Contains(movementAxis));
        if (movementAxis == "xz" || movementAxis == "XZ" || movementAxis == "ZX" || movementAxis == "zx"){
            original_z = transform.position.z;
            original_x = transform.position.x;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (movementAxis == "xz" || movementAxis == "XZ" || movementAxis == "ZX" || movementAxis == "zx"){
            float zVal = original_z + (Mathf.PingPong(Time.time * speed, 21));
            float xVal = original_x + (Mathf.PingPong(Time.time * speed, 21));
            transform.position = new Vector3(xVal, transform.position.y , zVal);
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