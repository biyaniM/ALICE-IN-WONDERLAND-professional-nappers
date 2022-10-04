using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverHUD : MonoBehaviour
{
    [SerializeField] Button restartBtn;
    [SerializeField] Button mainMenuBtn;

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
        Debug.Log("Game over end ui");
    }

    void ResetGame(){
        Debug.Log("Restart Game!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void BackToMain(){
        Debug.Log("Main Menu!");
        SceneManager.LoadScene("Menu");
    }
}
