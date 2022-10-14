using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelCompleteScreen: MonoBehaviour
{
    [SerializeField] Button restartBtn;
    [SerializeField] Button nextLevelBtn;
    [SerializeField] Button mainMenuBtn;
    [SerializeField] int curr_level;
    [SerializeField] CountDownTimer timer;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }
    
    public void Setup(){
        gameObject.SetActive(true);
        //release the cursor to press the button.
        Cursor.lockState = CursorLockMode.None;
        restartBtn.onClick.AddListener(ResetGame);
        mainMenuBtn.onClick.AddListener(BackToMain);
        if(SceneManager.GetActiveScene().buildIndex != 2){
            nextLevelBtn.onClick.AddListener(NextLevel);
        }
        Debug.Log("Setup game end ui");
        timer.pauseTimer();
        Debug.Log("paused timer!!!!----------------------");
    }

    void ResetGame(){
        Debug.Log("Restart Game!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void NextLevel(){
        curr_level = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("Next Level-------->");
        Debug.Log(curr_level);
        if(curr_level == 1){
            SceneManager.LoadScene("Group1_lvl");
        }
    }
    
    void BackToMain(){
        Debug.Log("Main Menu!");
        SceneManager.LoadScene("Menu");
    }
}
