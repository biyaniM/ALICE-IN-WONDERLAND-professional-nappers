using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialMenu : MonoBehaviour
{
    private Button backBtn;
    void Start()
    {
        backBtn = GameObject.Find("BackButton").GetComponent<Button>();
        backBtn.onClick.AddListener(BackMenu);
    }

    void BackMenu(){
        SceneManager.LoadScene("Menu");
    }
}
