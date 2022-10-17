using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

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
    public Canvas tutorial;
    public GameObject finishBoundary;

    public int numOfKill;
    [Header("Key Instructions")]
    [SerializeField] public bool enableKeyInstructions = false;
    public float keyInstructionTime = 10f;

    void Start()
    {
        
    }

    public void initializeStartup(){
        SetGoal(RED_GOAL, BLUE_GOAL, YELLOW_GOAL);
        // InitAmmo(80); //! Removinng from Test
        InitHealth(100);
        Debug.Log("INitializing HUD");
        InitializeHUD();

        // endboundary collider 
        Debug.Log("setting finish boundary something!!!");
        setFinishBoundary(true, "FinishBoundary", finishBoundary);
        

        SendToGoogle analyticsComponent = GetComponent<SendToGoogle>();
        analyticsComponent.Send(SceneManager.GetActiveScene().buildIndex.ToString(), "NA", "1", "NA", "NA");
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

}
