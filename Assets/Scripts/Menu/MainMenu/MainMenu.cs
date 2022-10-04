using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Button QuitButton;

    void Start(){
        QuitButton.onClick.AddListener(Quit);
    }


    void Quit(){
        Debug.Log("Quit the game!");
        Application.Quit();
    }
}
