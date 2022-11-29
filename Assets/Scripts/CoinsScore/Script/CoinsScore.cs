using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsScore : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public Text totalScore;
    [SerializeField] public Text Goal;
    private int gemGoal;
    private bool isTwoDigitsGoal;

    public void SetScores(int coins){
        coins = Math.Min(coins,gemGoal);
        if(coins == gemGoal){
            totalScore.color = new Color32(255, 36, 0, 242);
        }
        if(isTwoDigitsGoal && coins < 10){
            totalScore.text = "0" + coins.ToString();
        }else{
            totalScore.text = coins.ToString();
        }
        
    }

    public void SetGoals(int goal){
        gemGoal = goal;
        if(goal >= 10){
            isTwoDigitsGoal = true;
        }
        Goal.text = goal.ToString();
    }
}
