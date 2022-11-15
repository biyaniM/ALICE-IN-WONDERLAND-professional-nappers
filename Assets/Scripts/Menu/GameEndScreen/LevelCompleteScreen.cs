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
        Cursor.visible = true;
        restartBtn.onClick.AddListener(ResetGame);
        mainMenuBtn.onClick.AddListener(BackToMain);
        nextLevelBtn.onClick.AddListener(NextLevel);

        Debug.Log("Setup game end ui");
        timer.pauseTimer();
        Debug.Log("paused timer!!!!----------------------");
    }

    void ResetGame(){
        Debug.Log("Restart Game!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void NextLevel(){
        curr_level = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("Next Level-------->");
        Debug.Log(curr_level);
        switch(curr_level){
            case 1:{
                nextLevelBtn.enabled = true;
                SceneManager.LoadScene("old_level_2");
                break;
            }
            case 2:{
                nextLevelBtn.enabled = true;
                SceneManager.LoadScene("S_G_LEVEL_2");
                break;
            }
            case 3:{
                nextLevelBtn.enabled = true;
                SceneManager.LoadScene("level 2.5");
                break;
            }
            case 4:{
                nextLevelBtn.enabled = true;
                SceneManager.LoadScene("new_level_3");
                break;
            }
            case 5:{
                nextLevelBtn.enabled = true;
                SceneManager.LoadScene("new_level_4");
                break;
            }
            case 6:{
                nextLevelBtn.enabled = false;
                break;
            }
        }
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    void BackToMain(){
        Debug.Log("Main Menu!");
        SceneManager.LoadScene("Menu");
    }
}
