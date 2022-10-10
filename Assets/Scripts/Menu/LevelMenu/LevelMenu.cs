using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour

{
    public Button Level_0;
    public Button Level_1;
    public Button Level_2;

    void Start()
    {
        Level_0.onClick.AddListener(LeveLZero);
        Level_1.onClick.AddListener(LeveLOne);
        Level_2.onClick.AddListener(LeveLTwo);
    
    }

    public void LeveLZero(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void LeveLOne(){
        SceneManager.LoadScene("Group1_lvl" );
    }


    public void LeveLTwo(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }



}
