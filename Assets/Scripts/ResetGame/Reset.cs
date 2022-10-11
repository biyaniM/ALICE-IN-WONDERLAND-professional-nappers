using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    public float threshold = -20f;
    public healthUpdate gameOverHud;
    public LevelComplete level_complete_object;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if((transform.position.y < threshold) && !level_complete_object.levelOverCheck){
            gameOverHud.runGameOverHud();
            gameOverHud.timer.pauseTimer();
            level_complete_object.levelOverCheck = !level_complete_object.levelOverCheck;
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }    
    }
}
