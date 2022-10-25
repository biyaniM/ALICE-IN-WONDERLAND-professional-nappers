using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowKeyTutorial : MonoBehaviour
{
    private bool instructionComplete;
    [SerializeField] private string tutorialKind;
    private string tutorialMessage;
    private Player hud;
    // Start is called before the first frame update
    void Start()
    {
        hud = GameObject.Find("HUD").GetComponent<Player>();
    }

    // Update is called once per frame
    void SendTutorialMessage()
    {
        if (!instructionComplete){
            hud.ShowGuidance(tutorialMessage);
            Debug.Log(tutorialMessage,gameObject);
        }
    }

    void OnTriggerEnter(Collider col){
        switch (tutorialKind.ToLower()){
            case "movement":
                if (col.tag=="Player" && !instructionComplete){
                    instructionComplete = false;
                    tutorialMessage = "Use arrow keys to move";
                }
                break;

            case "jump":
                if (col.tag=="Player" && !instructionComplete){
                    instructionComplete = false;
                    tutorialMessage = "Use Spacebar to jump";
                }
                break;

            case "directed jump":
                if (col.tag=="Player" && !instructionComplete){
                    instructionComplete = false;
                    tutorialMessage = "Jump with arrow keys to direct your jump";
                }
                break;

            case "collect coin":
                if (col.tag=="Player" && !instructionComplete){
                    instructionComplete = false;
                    tutorialMessage = "Walk through coin to collect";
                }
                break;
            case "enemy close":
                if (col.tag=="Player" && !instructionComplete){
                    instructionComplete = false;
                    tutorialMessage = "Yellow enemy can shoot you!\nKill it to get coins!";
                }
                break;
            case "shoot enemy":
                if (col.tag=="Player" && !instructionComplete){
                    instructionComplete = false;
                    tutorialMessage = "Look towards enemy and press S to Shoot";
                }
                break;
            case "enemy cant shoot":
                if (col.tag=="Player" && !instructionComplete){
                    instructionComplete = false;
                    tutorialMessage = "Enemy can't shoot you if it can't see you";
                }
                break;
            case "sprint":
                if (col.tag=="Player" && !instructionComplete){
                    instructionComplete = false;
                    tutorialMessage = "Press Left Shift to Sprint";
                }
                break;
            case "enough coins":
                if (col.tag=="Player" && !instructionComplete){
                    instructionComplete = false;
                    tutorialMessage = "Collect enough coins!";
                }
                break;
            case "level finish":
                if (col.tag=="Player" && !instructionComplete){
                    instructionComplete = false;
                    tutorialMessage = "Pass through the arch!\nDo you enough coins?";
                }
                break;
            case "enemy give point":
                if (col.tag=="Player" && !instructionComplete){
                    instructionComplete = false;
                    tutorialMessage = "Killing enemies gives you coins!";
                }
                break;
        }
        SendTutorialMessage();
    }

    void OnTriggerExit(Collider col){
        if (col.tag=="Player" && !instructionComplete){
            instructionComplete = true;
            Debug.Log(tutorialKind+" completed");
            hud.CloseGuidance();
        }
    }
}
