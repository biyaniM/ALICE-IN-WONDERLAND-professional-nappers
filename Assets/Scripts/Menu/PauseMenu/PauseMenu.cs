using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public Button resume_btn;
    public Button menu_btn;
    public Button restart_btn;
    public Button guide_btn;
    public CountDownTimer timer;

    private void Start() {
        gameObject.SetActive(false);
    }


    public void Setup(){
        Debug.Log("Pause Menu Set");
        gameObject.SetActive(true);
        //release the cursor to press the button.
        Cursor.lockState = CursorLockMode.None;
        resume_btn.onClick.AddListener(Resume);
        menu_btn.onClick.AddListener(BackToMenu);
        restart_btn.onClick.AddListener(Restart);
        guide_btn.onClick.AddListener(ShowGuideMenu);
        timer.pauseTimer();
        
    }
    void Resume(){
        timer.resumeTimer();
    }

    void Restart(){
        Debug.Log("Restart Game!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void BackToMenu(){
        Debug.Log("Main Menu!");
        SceneManager.LoadScene("Menu");
    }

    void ShowGuideMenu(){

    }








}
