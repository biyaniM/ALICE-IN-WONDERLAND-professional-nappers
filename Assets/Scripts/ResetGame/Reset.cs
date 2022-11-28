using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    public float threshold = -20f;
    public healthUpdate gameOverHud;
    public LevelComplete level_complete_object;
    SendToGoogle analyticsComponent;

    // Start is called before the first frame update
    void Start()
    {
        analyticsComponent = GameObject.Find("HUD").GetComponent<SendToGoogle>();
    }

    // Update is called once per frame
    void Update()
    {
        try{
            if((transform.position.y < threshold) && !level_complete_object.levelOverCheck){
                string curr_level = SceneManager.GetActiveScene().buildIndex.ToString();
                if(curr_level != "3" && curr_level != "4"){
                    analyticsComponent.Send(SceneManager.GetActiveScene().buildIndex.ToString(), "NA", "Died", "NA", "NA", "NA", "Falling Down");
                }
                int numberOfTimesSpawned = gameOverHud.getNumberOfTimesSpawned();
                if(numberOfTimesSpawned <= 3) {

                    try {FindObjectOfType<AudioManager>().play("death");}
                    catch (System.NullReferenceException e) { Debug.LogWarning("Death sound not appointed in "+gameObject.scene+"\n"+e.ToString()); }

                    gameOverHud.updateHealth(0, 1);
                }
                else {

                    try {FindObjectOfType<AudioManager>().play("final death");}
                    catch (System.NullReferenceException e) { Debug.LogWarning("Death sound not appointed in "+gameObject.scene+"\n"+e.ToString()); }

                    gameOverHud.runGameOverHud();
                    // gameOverHud.timer.pauseTimer(); //! Already being called in healthUpdate.cs
                    level_complete_object.levelOverCheck = !level_complete_object.levelOverCheck;
                }
                // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }    
        }
        catch (System.NullReferenceException e){
            Debug.LogWarning(e.ToString());
        }
    }
}

                           
