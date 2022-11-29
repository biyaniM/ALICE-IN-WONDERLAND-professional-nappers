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
    private int usedTimes;
    // Update is called once per frame
    void Update()
    {
        usedTimes = healthUpdate.getNumberOfTimesSpawned();
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
