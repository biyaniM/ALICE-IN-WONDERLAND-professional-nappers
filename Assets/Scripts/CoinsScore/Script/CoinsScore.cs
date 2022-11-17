using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsScore : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public Text totalScore;
    [SerializeField] public Text Goal;

    public void SetScores(int coins){
        totalScore.text = coins.ToString();
    }

    public void SetGoals(int goal){
        Goal.text = goal.ToString();
    }
}
