using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinOnKillAlert : MonoBehaviour
{
    private Player hud;
    void Start()
    {
        hud = GameObject.Find("HUD").GetComponent<Player>();
    }

    private void OnCollisionEnter(Collision col) {
        Debug.Log("Collision Enter on Enemy Kill!");
        if (col.gameObject.name == "PaintBallProjectile(Clone)"){
                if (gameObject.tag=="enemy_red"){
                    SendMsg("Red");
                }
                else if (gameObject.tag=="enemy_yellow"){
                    SendMsg("Yellow");
                }
                else if (gameObject.tag=="enemy_blue"){
                    SendMsg("Blue");
                }
                else{
                    return;
                }
        }
    }

    private void OnCollisionExit(Collision other) {
        hud.CloseAlert();
    }

    void SendMsg(string color){
        string msg = "Killed " + color + "Enemy: + 1 " + color + " Coin";
        hud.ShowAlert(msg);
    }
}
