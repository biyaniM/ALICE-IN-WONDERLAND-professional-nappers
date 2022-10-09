using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation1 : MonoBehaviour
{

    [SerializeField] private Vector3 _rotation;
    [SerializeField] private float _speed; 


    // Use this for initialization
    void Start()
    {
        _speed = 20;
        StartCoroutine(RotateObject(90, Vector3.up, 3));
    }

    IEnumerator RotateObject(float angle, Vector3 axis, float inTime)
    {
        while (true)
        {
            // delay here
            yield return new WaitForSeconds(5);

            float deltaAngle = 0;

            // rotate until reaching angle
            while (deltaAngle < angle)
            {
                deltaAngle += _speed* Time.deltaTime;
                deltaAngle = Mathf.Min(deltaAngle, angle);

                transform.RotateAround(transform.position, Vector3.up, _speed*Time.deltaTime);
                Debug.Log("---------------------");
                Debug.Log(transform.position.x);
                Debug.Log(transform.position.y);
                Debug.Log(transform.position.z);
                Debug.Log("---------------------");
                // transform.Rotate(_rotation * Time.deltaTime);

                yield return null;
            }
            // delay here
            yield return new WaitForSeconds(5);
        }
    }

    // // Start is called before the first frame update
    // void Start()
    // {
    //     InvokeRepeating("rotate_sub_level", 5f, 5f);
    // }

    // // Update is called once per frame
    // void Update()
    // {

    //     // transform.Rotate(_rotation * Time.deltaTime);
    //     // transform.Rotate(_rotation * _speed * Time.deltaTime);
    // }

    // void rotate_sub_level(){
    //     Debug.Log(Time.time);
    //     transform.Rotate(_rotation * Time.deltaTime);
    //     Debug.Log("rotate end--------------");
    // }
} 
