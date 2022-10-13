using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammo_increment_mb : MonoBehaviour
{
    [SerializeField] private int boxDestroy = 3;
    public AmmoCount totalAmmo;
    // Start is called before the first frame update

    void Start()
    {
        
    }
    private void updateAmmo(int ammo)
    {
        totalAmmo.changeAmmoCount(ammo);
    }
    public void OnCollisionEnter(Collision col){
        if(col.gameObject.tag == "playerBullet"){
            Destroy(col.gameObject);
            boxDestroy = boxDestroy - 1;
            if(boxDestroy <= 0){
                Destroy(this.gameObject);
            }
            if(boxDestroy==0)
            {
                updateAmmo(ammo: 10);
            }
        }
    }
    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
