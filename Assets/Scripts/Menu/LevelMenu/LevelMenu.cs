using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour

{
    private Button Level_1;
    private Button Level_2;
    private Button Level_3;
    private Button Level_4;

    void Start()
    {
        Level_1 = GameObject.Find("Level_1").GetComponent<Button>();
        Level_2 = GameObject.Find("Level_2").GetComponent<Button>();
        Level_3 = GameObject.Find("Level_3").GetComponent<Button>();
        Level_4 = GameObject.Find("Level_4").GetComponent<Button>();

        Level_1.onClick.AddListener(LeveLOne);
        Level_2.onClick.AddListener(LeveLTwo);
        Level_3.onClick.AddListener(LeveLThree);
        Level_4.onClick.AddListener(LeveLFour);
    
    }

    public void LeveLOne(){
       SceneManager.LoadScene("Level_0");
    }

    public void LeveLTwo(){
        SceneManager.LoadScene("S_G_LEVEL_2");
    }

    public void LeveLThree(){
        SceneManager.LoadScene("new_level_3");
    }

    public void LeveLFour(){
        SceneManager.LoadScene("new_level_4");
    }



}
