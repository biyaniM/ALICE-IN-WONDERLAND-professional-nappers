using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsScore : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public Text totalScore;
    //[SerializeField] public Text blueScore;
    //[SerializeField] public Text yellowScore;
    [SerializeField] public Text Goal;
    //[SerializeField] public Text blueGoal;
    //[SerializeField] public Text yellowGoal;

    // public void SetScores(int red, int blue, int yellow){
    //     redScore.text = red.ToString();
    //     blueScore.text = blue.ToString();
    //     yellowScore.text = yellow.ToString();
    // }

    // public void SetGoals(int red, int blue, int yellow){
    //     redGoal.text = red.ToString();
    //     blueGoal.text = blue.ToString();
    //     yellowGoal.text = yellow.ToString();
    // }
    public void SetScores(int coins){
        totalScore.text = coins.ToString();
    }

    public void SetGoals(int goal){
        Goal.text = goal.ToString();
    }
}
