using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.EventSystems;

//source: https://www.youtube.com/watch?v=2gPHkaPGbpI
//clickalbe to pause
public class CountDownTimer : MonoBehaviour , IPointerClickHandler
{
    [SerializeField] GameOverHUD gameOverHUD;

    public void OnPointerClick(PointerEventData eventData)
    {
        Pause = !Pause;
    }

    //[SerializeField] private Image uiFill;
    [SerializeField] private Text uiText;

    public int Duration;

    public int remainingDuration;
    
    private bool Pause;

    private bool show_time_over_hud_flag;

    private void Start()
    {
        Begin(Duration);
        show_time_over_hud_flag = false;
    }

    private void Begin(int Second)
    {
        remainingDuration = Second;
        StartCoroutine(UpdateTimer());
    }

    public void pauseTimer(){
        Pause = true;
    }

    public void resumeTimer(){
        Pause = false;
    }

    private IEnumerator UpdateTimer()
    {
        while(remainingDuration >= 0)
        {

            if (!Pause)
            {
                uiText.text = $"{remainingDuration / 60:00}:{remainingDuration % 60:00}";
                //uiFill.fillAmount = Mathf.InverseLerp(0, Duration, remainingDuration);
                remainingDuration--;
                yield return new WaitForSeconds(1f);
            }
            yield return null;
            if(Pause == true){
                show_time_over_hud_flag = true;
            }
        }
        if(!show_time_over_hud_flag){
            OnEnd();
        }
    }

    private void OnEnd()
    {
        Debug.Log("Game over hud from countown timer!!");
        string msg = "You Died!";
        gameOverHUD.Setup(msg);
        //End Time , if want Do something
        print("End");
        
        //! if slider.value  <= 0: trigger the game over HUD
        
    }
}
