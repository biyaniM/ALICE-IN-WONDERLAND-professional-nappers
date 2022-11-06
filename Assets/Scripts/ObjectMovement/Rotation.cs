using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float angle = 10f;
    public float roatationSpeed = 0.15f;
    public bool noKill = false;
    protected GameObject emptyParentingGameObject;

    void Start(){

    }
    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.position, Vector3.up, angle * roatationSpeed);
    }

    void OnTriggerEnter(Collider collider){
        if (!noKill){
            if (collider.tag == "Player"){
                //* Reparenting with an empty game object to make local scale of player (1,1,1).
                emptyParentingGameObject = new GameObject();
                emptyParentingGameObject.transform.parent = transform;
                collider.transform.parent = emptyParentingGameObject.transform;

            }
        }
    }
    void OnTriggerExit(Collider collider){
        if (!noKill){
            if (collider.tag == "Player"){
                //* Reparent to original state
                collider.transform.parent = null;
                //* Destroy the empty parenting GO for performance
                Destroy(emptyParentingGameObject);
            }
        }
    }
}
