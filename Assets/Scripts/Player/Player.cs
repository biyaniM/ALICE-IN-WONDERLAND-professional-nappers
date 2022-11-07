using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 
using TMPro;

public class Player : MonoBehaviour
{
    //Attributes
    private int healthPoint;
    private int redCoins;
    private int blueCoins;
    private int yellowCoins;
    private int ammoBalance;
    //fake const(set from outside)
    private int SUM_AMMO;
    private int SUM_HEALTH;
    [SerializeField] int RED_GOAL;
    [SerializeField] int BLUE_GOAL;
    [SerializeField] int YELLOW_GOAL;
    [SerializeField] int LEVEL_SELECT;
    // UI components
    public HealthBar healthBar;
    public CoinsScore coinsScore;
    public AmmoCount ammoCount;
    private TextMeshProUGUI guidance;
    private TextMeshProUGUI alert;
    public GameObject finishBoundary;
    public PauseMenu pauseMenu;
    public int numOfKill;
    


    void Start()
    {
        SetComponents();
        SetGoal(RED_GOAL, BLUE_GOAL, YELLOW_GOAL);
        // InitAmmo(80); //! Removinng from Test
        InitHealth(100);
        InitializeHUD();

        // endboundary collider 
        Debug.Log("setting finish boundary something!!!");
        setFinishBoundary(true, "FinishBoundary", finishBoundary);
        

        SendToGoogle analyticsComponent = GetComponent<SendToGoogle>();
        analyticsComponent.Send(SceneManager.GetActiveScene().buildIndex.ToString(), "NA", "Started", "NA", "NA", "NA", "NA");

    }

    //todo: fix all ui component here  
    void SetComponents(){
        guidance = GameObject.Find("Guidance").GetComponent<TextMeshProUGUI>();
        guidance.enabled = false;
        alert = GameObject.Find("Alert").GetComponent<TextMeshProUGUI>();
        alert.enabled = false;
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.P)){
            if(pauseMenu.GameIsPaused){
                // resume the game
                pauseMenu.Resume();
            }
            else{
                // pause the game
                Debug.Log("Pause the game");
                pauseMenu.Setup();
            }
        }
    }

    public void UpdateHealth(int health){
        healthPoint = health;
        healthBar.SetHealth(healthPoint);
    }

    public void UpdateCoins(int red, int blue, int yellow){
        redCoins = red;
        blueCoins = blue;
        yellowCoins = yellow;
        coinsScore.SetScores(redCoins, blueCoins, yellowCoins);
        RenderSettings.skybox.SetColor("_Tint", new Color(15*red/255f, 15*yellow/255f, 15*blue/255f));
    }

    public void UpdateAmmo(int ammoAmount){
        ammoBalance = ammoAmount;
        ammoCount.SetBalance(ammoBalance);
    }
    //import setting from level side
    void SetGoal(int redGoal, int blueGoal, int yellowGoal){
        RED_GOAL = redGoal;
        BLUE_GOAL = blueGoal;
        YELLOW_GOAL = yellowGoal;
        coinsScore.SetGoals(RED_GOAL, BLUE_GOAL, YELLOW_GOAL);
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
        redCoins = 0;
        blueCoins = 0;
        yellowCoins = 0;
        Debug.Log("Initialize HUD values");
    }

    //check if the player has collected enough colors
    public void CheckGoal(int red, int blue, int yellow){
        if(red >= RED_GOAL && blue >= BLUE_GOAL && yellow >= YELLOW_GOAL){
                // finishBoundary.GetComponent<BoxCollider>().enabled = false;
                setFinishBoundary(false, "FinishBoundary", finishBoundary);
        }


    }

    public void setFinishBoundary(bool param, string finish, GameObject finishBoundary){
        finishBoundary = GameObject.Find(finish);
        finishBoundary.GetComponent<BoxCollider>().enabled = param;
    }

    public int GetRedCoinsScore(){
        return redCoins;
    }

    public int GetBlueCoinsScore(){
        return blueCoins;
    }

    public int GetYellowCoinsScore(){
        return yellowCoins;
    }

    public void UpdateNumberOfKill()
    {
        numOfKill++;
    }
    public int GetNumberOfKill()
    {
        return numOfKill;
    }

    public void ShowGuidance(string msg){
        guidance.enabled = true;
        guidance.text = msg;
    }

    public void CloseGuidance(){
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
