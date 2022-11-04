using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class MovePingPong : MonoBehaviour
{
    [Header("Object Movement Settings")]
    public float speed = 5f;
    public float movementMultiplier = 3f;
    private float original;
    private List<char> movementAxisSelectionOptions = new List<char> {'X','Y','Z','x','y','z'};
    public char movementAxis;
    protected GameObject emptyParentingGameObject;
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
        // Debug.Log("ORIGINAL "+original);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (movementAxis == 'Z' || movementAxis == 'z'){
            float zVal = original + movementMultiplier * Mathf.Sin(Mathf.PingPong(Time.time, 2* Mathf.PI));
            transform.position = new Vector3(transform.position.x, transform.position.y , zVal);
        }
        else if (movementAxis == 'X' || movementAxis == 'x'){
            float xVal = original + movementMultiplier * Mathf.Sin(Mathf.PingPong(Time.time, 2* Mathf.PI));
            transform.position = new Vector3(xVal, transform.position.y , transform.position.z);
        }
        else{
            float yVal = original + movementMultiplier * Mathf.Sin(Mathf.PingPong(Time.time, 2* Mathf.PI));
            transform.position = new Vector3(transform.position.x, yVal , transform.position.z);
        }
    }

    private void OnTriggerEnter(Collider collider){
        if (collider.tag == "Player"){
            //* Reparenting with an empty game object to make local scale of player (1,1,1).
            emptyParentingGameObject = new GameObject();
            emptyParentingGameObject.transform.parent = transform;
            collider.transform.parent = emptyParentingGameObject.transform;
        }
    }

    private void OnTriggerExit(Collider collider){
        if (collider.tag == "Player"){
            //* Reparent to original state
            collider.transform.parent = null;
            //* Destroy the empty parenting GO for performance
            Destroy(emptyParentingGameObject);
        }
    }
}
