using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachPlayerOnly : MonoBehaviour
{
    [SerializeField] private GameObject player;
    void OnTriggerEnter(Collider collider){
        // transform.sib
        if (collider.gameObject == player && collider.transform.parent == null){
            collider.transform.SetParent(transform, true);
        }
    }
    void OnTriggerExit(Collider collider){
        if (collider.gameObject == player){
            collider.transform.parent = null;
        }
    }
}
