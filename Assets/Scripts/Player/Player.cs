using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 
using TMPro;
using StarterAssets;

public class Player : MonoBehaviour
{
    //Attributes
    private int healthPoint;
    private int collectedCoins;
    private int ammoBalance;
    private float saturation;
    //fake const(set from outside)
    private int SUM_AMMO;
    private int SUM_HEALTH;
    private float SATURATION_INCREASE_FACTOR;
    [SerializeField] int TOTAL_GOAL;
    [SerializeField] int LEVEL_SELECT;
    // UI components
    public HealthBar healthBar;
    public CoinsScore coinsScore;
    public AmmoCount ammoCount;
    private TextMeshProUGUI guidance;
    public Image guidanceArea;
    private TextMeshProUGUI alert;
    public GameObject finishBoundary;
    // public PauseMenu pauseMenu;
    public int numOfKill;
    private bool isEnd;


    void Start()
    {
        SetComponents();
        SetGoal(TOTAL_GOAL);

        saturation = -100f;

        InitHealth(100);
        InitializeHUD();
        SetGameStatus(false);

        // endboundary collider 
        Debug.Log("setting finish boundary something!!!");
        setFinishBoundary(true, "FinishBoundary", finishBoundary);
        

        SendToGoogle analyticsComponent = GetComponent<SendToGoogle>();
        analyticsComponent.Send(SceneManager.GetActiveScene().buildIndex.ToString(), "NA", "Started", "NA", "NA", "NA", "NA");

    }

    //todo: fix all ui component here  
    void SetComponents(){
        guidanceArea.enabled = false;
        guidance = GameObject.Find("Guidance").GetComponent<TextMeshProUGUI>();
        guidance.enabled = false;
        alert = GameObject.Find("Alert").GetComponent<TextMeshProUGUI>();
        alert.enabled = false;
        
    }

    void Update(){

    }

    public void UpdateHealth(int health){
        healthPoint = health;
        healthBar.SetHealth(healthPoint);
    }

    public void UpdateCoins(int coins){
        int prevCoins = collectedCoins;
        int changeCoins = coins - collectedCoins;
        collectedCoins = coins;
        float changeSaturation = 0;
        if(prevCoins == 0){
            if(changeCoins == 1){
                if(TOTAL_GOAL < 10){
                    changeSaturation = 50f;
                }
                else if(TOTAL_GOAL < 20){
                    changeSaturation = 100f/3f;
                }
                else{
                    changeSaturation = 20f;
                }
                
            }
            else if(changeCoins == 2){
                if(TOTAL_GOAL < 10){
                    changeSaturation = 75f;
                }
                else if(TOTAL_GOAL < 20){
                    changeSaturation = 50f;
                }
                else{
                    changeSaturation = 30f;
                }
            }
            else{
                if(TOTAL_GOAL < 10){
                    changeSaturation = 75f + (changeCoins - 2) * SATURATION_INCREASE_FACTOR;
                }
                else if(TOTAL_GOAL < 20){
                    changeSaturation = 50f + (changeCoins - 2) * SATURATION_INCREASE_FACTOR;
                }
                else{
                    changeSaturation = 50f + (changeCoins - 2) * SATURATION_INCREASE_FACTOR;
                }
            }
        }
        else if(prevCoins == 1){
            if(changeCoins == 1){
                if(TOTAL_GOAL < 10){
                    changeSaturation = 25f;
                }
                else if(TOTAL_GOAL < 20){
                    changeSaturation = 50f/3f;
                }
                else{
                    changeSaturation = 10f;
                }
                
            }
            else{
                changeSaturation = (50f/3f) + (changeCoins - 1) * SATURATION_INCREASE_FACTOR;
            }
        }
        else{
            changeSaturation = changeCoins * SATURATION_INCREASE_FACTOR;
        }
        
        saturation = Mathf.Min(25f, saturation + changeSaturation);
        coinsScore.SetScores(collectedCoins);
        RenderSettings.skybox.SetColor("_Tint", new Color(15*coins/255f, 15*coins/255f, 15*coins/255f));
    }

    public void UpdateAmmo(int ammoAmount){
        ammoBalance = ammoAmount;
        ammoCount.SetBalance(ammoBalance);
    }
    //import setting from level side
    void SetGoal(int totalGoal){
        TOTAL_GOAL = totalGoal;
        if(TOTAL_GOAL < 10){
            SATURATION_INCREASE_FACTOR = 50f / (TOTAL_GOAL - 2);
        }
        else if(TOTAL_GOAL < 20){
            SATURATION_INCREASE_FACTOR = 75f / (TOTAL_GOAL - 2);
        }
        else{
            SATURATION_INCREASE_FACTOR = 95f / (TOTAL_GOAL - 2);
        }
        
        coinsScore.SetGoals(TOTAL_GOAL);
    }
    //import from player shooting???
    public void InitAmmo(int ammoAmount){
        SUM_AMMO = ammoAmount;
        ammoCount.SetTotalAmmo(SUM_AMMO);
    }

    void InitHealth(int health){
        SUM_HEALTH = health;
        healthBar.SetMaxHealth(SUM_HEALTH);
    }

    void InitializeHUD(){
        healthPoint = SUM_HEALTH;
        ammoBalance = SUM_AMMO;
        collectedCoins = 0;
        Debug.Log("Initialize HUD values");
    }

    //check if the player has collected enough coins
    public void CheckGoal(int coins){
        if(coins >= TOTAL_GOAL){
            setFinishBoundary(false, "FinishBoundary", finishBoundary);
        }
    }

    public void setFinishBoundary(bool param, string finish, GameObject finishBoundary){
        finishBoundary = GameObject.Find(finish);
        finishBoundary.GetComponent<BoxCollider>().enabled = param;
    }
    
    public int GetCoinsScore(){
         return collectedCoins;
    }

    public float GetSaturation(){
        return saturation;
    }

    public void UpdateNumberOfKill()
    {
        numOfKill++;
    }
    public int GetNumberOfKill()
    {
        return numOfKill;
    }

    public void SetGameStatus(bool status){
        isEnd = status;
    }

    public bool GetGameStatus(){
        return isEnd;
    }

    public void ShowGuidance(string msg){
        guidanceArea.enabled = true;
        guidance.enabled = true;
        guidance.text = msg;
    }

    public void CloseGuidance(){
        guidanceArea.enabled = false;
        guidance.enabled = false;
    }

    public void ShowAlert(string msg){
        alert.enabled = true;
        alert.text = msg;
    }

    public void CloseAlert(){
        alert.enabled = false;
    }



}
