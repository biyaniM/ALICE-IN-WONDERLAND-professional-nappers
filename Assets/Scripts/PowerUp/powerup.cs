using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerup : MonoBehaviour
{
    public GameObject pickupEffect;
    public float multiplier = 2.4f;
    
    void OnTriggerEnter (Collider col)
    {
        if (col.CompareTag("Player"))
        {
            StartCoroutine(Pickup(col));
        }
    }

    IEnumerator Pickup(Collider player)
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);

        //player.transform.localScale *= multiplier;

        healthUpdate update = player.GetComponent<healthUpdate>();
        update.currentHealth = update.maxHealth;
        update.updateHealth(update.currentHealth);

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<SphereCollider>().enabled = false;

        yield return new WaitForSeconds(20f);
        //update.currentHealth = update.currentHealth;
        //player.transform.localScale /= multiplier;

        Destroy(gameObject);
    }

}
