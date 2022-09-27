using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBox : MonoBehaviour
{
    [SerializeField] private int boxDestroy = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnCollisionEnter(Collision col){
        if(col.gameObject.tag == "playerBullet"){
            Destroy(col.gameObject);
            boxDestroy = boxDestroy - 1;
            if(boxDestroy <= 0){
                Destroy(this.gameObject);
            }
        }
        return;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
