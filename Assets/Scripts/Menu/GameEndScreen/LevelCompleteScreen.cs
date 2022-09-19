using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelCompleteScreen: MonoBehaviour
{
    [SerializeField] Button restartBtn;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        restartBtn.onClick.AddListener(ResetGame);
    }
    
    public void Setup(){
        gameObject.SetActive(true);
        Debug.Log("Setup game end ui");
    }

    void ResetGame(){
        Debug.Log("Restart Game");
    }


}
