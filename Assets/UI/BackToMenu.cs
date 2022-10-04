using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    public Button BackToMenuButton;
    void Start()
    {
        BackToMenuButton.onClick.AddListener(BackMenu);
    }

    public void BackMenu(){
        Debug.Log("TAKE ME BACK TO MAIN PLZ!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
