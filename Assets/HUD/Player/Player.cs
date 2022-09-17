using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    private int RED_GOAL;
    private int BLUE_GOAL;
    private int YELLOW_GOAL;
    // UI components
    public HealthBar healthBar;
    public CoinsScore coinsScore;
    public AmmoCount ammoCount;
    public Canvas tutorial;

    void Start()
    {
        //test
        SetGoal(10, 10, 10);
        InitAmmo(80);
        InitHealth(100);
        InitializeHUD();
    }

    void Update(){
        Debug.Log("Time" + Time.time);
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
    void InitAmmo(int ammoAmount){
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
        redCoins = RED_GOAL;
        blueCoins = BLUE_GOAL;
        yellowCoins = YELLOW_GOAL;
        Debug.Log("Initialize HUD values");
    }

}
