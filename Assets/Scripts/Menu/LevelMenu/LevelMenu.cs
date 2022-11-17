using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour

{
    private Button Level_1;
    private Button Level_old_2;
    private Button Level_2;
    private Button Level_3;
    private Button Level_4;
    private Button Level_5;

    void Start()
    {
        Level_1 = GameObject.Find("Level_1").GetComponent<Button>();
        Level_old_2 = GameObject.Find("Level_old_2").GetComponent<Button>();
        Level_2 = GameObject.Find("Level_2").GetComponent<Button>();
        Level_3 = GameObject.Find("Level_3").GetComponent<Button>();
        Level_4 = GameObject.Find("Level_4").GetComponent<Button>();
        Level_5 = GameObject.Find("Level_5").GetComponent<Button>();

        Level_1.onClick.AddListener(LeveLOne);
        Level_old_2.onClick.AddListener(LevelOldTwo);
        Level_2.onClick.AddListener(LeveLTwo);
        Level_3.onClick.AddListener(LeveLThree);
        Level_4.onClick.AddListener(LeveLFour);
        Level_5.onClick.AddListener(LeveLFive);
    }

    public void LeveLOne(){
       SceneManager.LoadScene("Level_0");
       Cursor.visible = false;
    }

    public void LevelOldTwo(){
        SceneManager.LoadScene("old_level_2");
        Cursor.visible = false;
    }

    public void LeveLTwo(){
        SceneManager.LoadScene("S_G_LEVEL_2");
        Cursor.visible = false;
    }

    public void LeveLThree(){
        SceneManager.LoadScene("level 2.5");
        Cursor.visible = false;
    }

    public void LeveLFour(){
        SceneManager.LoadScene("new_level_3");
        Cursor.visible = false;
    }

    public void LeveLFive(){
        SceneManager.LoadScene("new_level_4");
        Cursor.visible = false;
    }

}
