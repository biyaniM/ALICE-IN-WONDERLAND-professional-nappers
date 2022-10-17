using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InLevelPause : MonoBehaviour
{
  public Button pause_btn;
  public Canvas PauseMenu;
  void Start(){
      //pause_btn = gameObject.GetComponent<Button>();
      //PauseMenu = GameObject.Find("PauseMenu").GetComponent<Canvas>();
      pause_btn.onClick.AddListener(ShowPauseMenu);
  }

  void ShowPauseMenu(){
      Cursor.lockState = CursorLockMode.None;
      Debug.Log("Pause Menu Show up");
      PauseMenu.enabled = true;
  }
}