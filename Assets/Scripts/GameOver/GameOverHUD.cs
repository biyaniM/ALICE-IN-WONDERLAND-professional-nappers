using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using StarterAssets;

public class GameOverHUD : MonoBehaviour
{
    [SerializeField] Button restartBtn;
    [SerializeField] Button mainMenuBtn;
    private Text gameOverText;
    private Player player;
    private ThirdPersonController controller;

    void Awake(){
        controller = GameObject.FindGameObjectWithTag("Player").GetComponent<ThirdPersonController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("HUD").GetComponent<Player>();
        gameObject.SetActive(false);   
        //gameOverText = GameObject.Find("LevelCompleteText").GetComponent<Text>();
    }

    public void Setup(string msg){
        gameObject.SetActive(true);
        //release the cursor to press the button.
        Cursor.lockState = CursorLockMode.None;
        restartBtn.onClick.AddListener(ResetGame);
        mainMenuBtn.onClick.AddListener(BackToMain);
        //gameOverText.text = msg;
        Debug.Log("Game over end ui");
        player.SetGameStatus(true);
        Time.timeScale = 0f;
        controller.isPaused = true;
    }

    void ResetGame(){
        Debug.Log("Restart Game!");
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        controller.isPaused = false;
    }

    void BackToMain(){
        Debug.Log("Main Menu!");
        Time.timeScale = 1;
        //SceneManager.LoadScene("Menu");
        SceneManager.LoadScene("New_Menu");
        controller.isPaused = true;
    }
}
