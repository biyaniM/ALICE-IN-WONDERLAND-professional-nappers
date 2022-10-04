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
    // UI components
    public HealthBar healthBar;
    public CoinsScore coinsScore;
    public AmmoCount ammoCount;
    public Canvas tutorial;

    public GameObject finishBoundary;

    public int numOfKill;


    void Start()
    {
        SetGoal(RED_GOAL, BLUE_GOAL, YELLOW_GOAL);
        // InitAmmo(80); //! Removinng from Test
        InitHealth(100);
        InitializeHUD();
        // endboundary collider 
        setFinishBoundary(true);

        SendToGoogle analyticsComponent = GetComponent<SendToGoogle>();
        analyticsComponent.Send(SceneManager.GetActiveScene().buildIndex.ToString(), "NA", "1", "NA", "NA");

    }

    void Update(){
        // Debug.Log("Time" + Time.time); //TODO Commenting it out to make other Debug logs readable
        if(tutorial.enabled && Time.time >= 5f){
            tutorial.enabled = false;
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
        if(red >= RED_GOAL && blue >= BLUE_GOAL && yellow>= YELLOW_GOAL){
            finishBoundary = GameObject.Find("FinishBoundary");
            finishBoundary.GetComponent<BoxCollider>().enabled = false;
            // finishBoundary.enabled = false;
            // Destroy(finishBoundary);
            //end game display ui
        }
    }

    public void setFinishBoundary(bool param){
        finishBoundary = GameObject.Find("FinishBoundary");
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
