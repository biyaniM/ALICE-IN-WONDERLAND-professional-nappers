using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotating_cylinder : MonoBehaviour
{
    [SerializeField] private Vector3 _rotation;
    [SerializeField] private float _speed;

    [SerializeField] private bool rotation_clockwise;

    // Start is called before the first frame update
    void Start()
    {   
        _speed = 30;
        if (rotation_clockwise){
            StartCoroutine(RotateObject(90, Vector3.forward, 3));
        }
        else{
            StartCoroutine(RotateObject(90, Vector3.back, 3));
        }
    }

    IEnumerator RotateObject(float angle, Vector3 axis, float inTime)
    {
        while (true)
        {
            // delay here
            // yield return new WaitForSeconds(3);

            float deltaAngle = 0;

            // rotate until reaching angle
            while (deltaAngle < angle)
            {
                deltaAngle += _speed* Time.deltaTime;
                deltaAngle = Mathf.Min(deltaAngle, angle);

                transform.RotateAround(transform.position, axis, _speed*Time.deltaTime);
                // Debug.Log("---------------------");
                // Debug.Log(transform.position.x);
                // Debug.Log(transform.position.y);
                // Debug.Log(transform.position.z);
                // Debug.Log("---------------------");
                // transform.Rotate(_rotation * Time.deltaTime);

                yield return null;
            }
            // delay here
            // yield return new WaitForSeconds(3);
        }
    }
}
