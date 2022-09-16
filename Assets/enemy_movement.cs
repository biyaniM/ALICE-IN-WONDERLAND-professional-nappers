using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_movement : MonoBehaviour
{


    // public Transform player;
    // public float speed = 2f;
    // private void update()
    // {
    //     Vector3 vectorToTarget = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
    //     transform.LookAt(vectorToTarget);
    // }

    public float speed;
    public GameObject player;
    public float rotationModifier;

     private void FixedUpdate()
    {
        if (player != null)
        {
            Vector3 vectorToTarget = player.transform.position - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - rotationModifier;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);
        }
    }
    // Start is called before the first frame update
}
