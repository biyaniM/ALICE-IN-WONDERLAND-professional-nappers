using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private Button GuideBtn;

    void Start(){
        GuideBtn = GameObject.Find("Guide").GetComponent<Button>();
        GuideBtn.onClick.AddListener(ShowGuideScene);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }


    void ShowGuideScene(){
        SceneManager.LoadScene("TutorialScene");
        Cursor.lockState = CursorLockMode.None;
    }
}
