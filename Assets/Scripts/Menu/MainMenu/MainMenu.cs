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
    }


    void ShowGuideScene(){
        SceneManager.LoadScene("TutorialScene");
    }
}
