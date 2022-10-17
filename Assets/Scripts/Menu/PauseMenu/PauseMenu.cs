using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private Button resume_btn;
    private Button menu_btn;
    private Button restart_btn;
    private Button guide_btn;

    private void Start() {
        resume_btn = GameObject.Find("Resume_Button").GetComponent<Button>();
        menu_btn = GameObject.Find("MainMenu_Button").GetComponent<Button>();
        restart_btn = GameObject.Find("Restart_Button").GetComponent<Button>();
        guide_btn = GameObject.Find("Guidance_Button").GetComponent<Button>();

        resume_btn.onClick.AddListener(Resume);
        menu_btn.onClick.AddListener(Restart);
        restart_btn.onClick.AddListener(BackToMenu);
        guide_btn.onClick.AddListener(ShowGuideMenu);
    }

    void Resume(){

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
