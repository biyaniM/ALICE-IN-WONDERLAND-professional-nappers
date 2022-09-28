using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_to_and_fro : enemy
{
    public float speed = 2.5f;
    void Update()
    {
        base.Update();
        transform.position = new Vector3(Mathf.PingPong(Time.time * speed, 2), transform.position.y, transform.position.z);
    }

}
