using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
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
    // public Transform Target;
    // public float Speed = 2f;

    // private Coroutine LookCoroutine;

    // void Start()
    // {
    //     StartCoroutine(LookAt());
    //     // StartRotating();
    // }

    // public void StartRotating()
    // {
    //     if (LookCoroutine != null)
    //     {
    //         StopCoroutine(LookCoroutine);
    //     }

    //     LookCoroutine = StartCoroutine(LookAt());
    // }

    // private IEnumerator LookAt()
    // {
    //     Quaternion lookRotation = Quaternion.LookRotation(Target.position - transform.position);

    //     float time = 0;

    //     Quaternion initialRotation = transform.rotation;
    //     while (time < 1)
    //     {
    //         transform.rotation = Quaternion.Slerp(initialRotation, lookRotation, time);

    //         time += Time.deltaTime * Speed;

    //         yield return null;
    //     }
    // }

    // // You can remove this, it is only for the demo.
    // private void OnGUI()
    // {
    //     if (GUI.Button(new Rect(10, 10, 200, 30), "Look At"))
    //     {
    //         StartRotating();
    //     }
    // }
}

