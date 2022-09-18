using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoCount : MonoBehaviour
{
    [SerializeField] public Text balance;
    private int totalAmmo;

    public void SetTotalAmmo(int total){
        totalAmmo = total;
        balance.text = total.ToString();
        Debug.Log("Total Ammo" + balance);
    }

    public void SetBalance(int count){
        //balance.text = (totalAmmo - count).ToString();
        balance.text = count.ToString();
    }
}
