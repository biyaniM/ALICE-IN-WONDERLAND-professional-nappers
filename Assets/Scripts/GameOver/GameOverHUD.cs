using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverHUD : MonoBehaviour
{
    [SerializeField] Button restartBtn;
    [SerializeField] Button mainMenuBtn;
    private Text gameOverText;
    private Player player;

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
    }

    void ResetGame(){
        Debug.Log("Restart Game!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void BackToMain(){
        Debug.Log("Main Menu!");
        //SceneManager.LoadScene("Menu");
        SceneManager.LoadScene("New_Menu");
    }
}
