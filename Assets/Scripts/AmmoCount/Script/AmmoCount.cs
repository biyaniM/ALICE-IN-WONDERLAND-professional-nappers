using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoCount : MonoBehaviour
{
    [SerializeField] public Text balance;
    public int totalAmmo;
    public int currentAmmo;

    public void SetTotalAmmo(int total){
        totalAmmo = total;
        currentAmmo = total;
        balance.text = total.ToString();
        Debug.Log("Total Ammo" + balance);
    }

    public void SetBalance(int count){
        currentAmmo = count;
        balance.text = currentAmmo.ToString();
        // balance.text = count.ToString();
    }
}