using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using StarterAssets;

public class LevelCompleteScreen: MonoBehaviour
{
    [SerializeField] Button restartBtn;
    [SerializeField] Button nextLevelBtn;
    [SerializeField] Button mainMenuBtn;
    [SerializeField] int curr_level;
    [SerializeField] CountDownTimer timer;
    private ThirdPersonController controller;

    void Awake(){
        controller = GameObject.FindGameObjectWithTag("Player").GetComponent<ThirdPersonController>();
    }

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
        controller.isPaused = true;
        Debug.Log("Setup game end ui");
        timer.pauseTimer();
        Time.timeScale = 0f;
        Debug.Log("paused timer!!!!----------------------");
    }

    void ResetGame(){
        Debug.Log("Restart Game!");
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        controller.isPaused = false;
    }

    void NextLevel(){
        Time.timeScale = 1;
        curr_level = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("Next Level-------->");
        Debug.Log(curr_level);
        switch(curr_level){
            case 1:{
                nextLevelBtn.enabled = true;
                SceneManager.LoadScene("Level 2");
                break;
            }
            case 2:{
                nextLevelBtn.enabled = true;
                SceneManager.LoadScene("Level 3");
                break;
            }
            case 3:{
                nextLevelBtn.enabled = true;
                SceneManager.LoadScene("Level 4");
                break;
            }
            case 4:{
                nextLevelBtn.enabled = true;
                SceneManager.LoadScene("Level 5");
                break;
            }
            case 5:{
                nextLevelBtn.enabled = true;
                SceneManager.LoadScene("Level 6");
                break;
            }
            case 6:{
                nextLevelBtn.enabled = true;
                SceneManager.LoadScene("Level 7");
                break;
            }
            case 7:{
                nextLevelBtn.enabled = true;
                SceneManager.LoadScene("Level 8");
                break;
            }
            case 8:{
                nextLevelBtn.enabled = false;
                break;
            }            
        }
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        controller.isPaused = true;
    }
    
    void BackToMain(){
        Time.timeScale = 1;
        Debug.Log("Main Menu!");
        //SceneManager.LoadScene("Menu");
        SceneManager.LoadScene("New_Menu");
        controller.isPaused = true;
    }
}
