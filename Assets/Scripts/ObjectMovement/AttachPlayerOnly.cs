using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachPlayerOnly : MonoBehaviour
{
    void OnTriggerEnter(Collider collider){
        // transform.sib
        if (collider.tag == "Player" && collider.transform.parent == null){
            collider.transform.SetParent(transform, true);
        }
    }
    void OnTriggerExit(Collider collider){
        if (collider.tag == "Player"){
            collider.transform.parent = null;
        }
    }
}
