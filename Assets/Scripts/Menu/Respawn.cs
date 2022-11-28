using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Respawn : MonoBehaviour
{
    //left to right heart
    public Image CP1;//checkpoint 1
    public Image CP2;
    public Image CP3;
    public Image CP4;
    public healthUpdate healthUpdate;
    public int usedTimes;
    // Update is called once per frame
    void Update()
    {
        // usedTimes = healthUpdate.getNumberOfTimesSpawned();
        // Debug.Log("usedTimeds");
        // Debug.Log(usedTimes);
        // switch (usedTimes)
        // {
        //     case 2:
        //         CP4.enabled = false;
        //         break;
        //     case 3:
        //         CP3.enabled = false;
        //         break;
        //     case 4:
        //         CP2.enabled = false;
        //         break;
        //     case 5:
        //         CP1.enabled = false;
        //         break;
        //     default:
        //         break;
        // }

    }

    // try not to have checks in update function unless necessary.
    public void update_respawn_ui(int usedTimes){
        Debug.Log(usedTimes);
        switch (usedTimes)
        {
            case 2:
                CP4.enabled = false;
                break;
            case 3:
                CP3.enabled = false;
                break;
            case 4:
                CP2.enabled = false;
                break;
            case 5:
                CP1.enabled = false;
                break;
            default:
                break;
        }
    }
}
