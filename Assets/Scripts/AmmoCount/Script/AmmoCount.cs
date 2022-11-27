using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoCount : MonoBehaviour
{
    [SerializeField] public Text balance;
    [SerializeField] public Text ammoTotal;
    public int totalAmmo;
    public int currentAmmo;

    public void SetTotalAmmo(int total){
        totalAmmo = total;
        currentAmmo = total;
        balance.text = total.ToString();
        ammoTotal.text = total.ToString();
        Debug.Log("Total Ammo" + balance);
    }

    public void SetBalance(int count){
        currentAmmo = count;
        balance.text = currentAmmo.ToString();
        // balance.text = count.ToString();
    }

    public void increaseAmmoCount(int count){
        Debug.Log("Updated ammo ::: "+ count);
        currentAmmo += count;
        SetBalance(Mathf.Min(currentAmmo,totalAmmo));
        Debug.Log("Current ammo ::: "+ currentAmmo);
    }
    public void decreaseAmmoCount(int count){
        Debug.Log("Updated ammo ::: "+ count);
        currentAmmo -= count;
        SetBalance(Mathf.Max(currentAmmo,0));
        Debug.Log("Current ammo ::: "+ currentAmmo);
    }
}
