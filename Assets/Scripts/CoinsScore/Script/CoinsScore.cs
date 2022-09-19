using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsScore : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public Text redScore;
    [SerializeField] public Text blueScore;
    [SerializeField] public Text yellowScore;
    [SerializeField] public Text redGoal;
    [SerializeField] public Text blueGoal;
    [SerializeField] public Text yellowGoal;

    public void SetScores(int red, int blue, int yellow){
        redScore.text = red.ToString();
        blueScore.text = blue.ToString();
        yellowScore.text = yellow.ToString();
    }

    public void SetGoals(int red, int blue, int yellow){
        redGoal.text = red.ToString();
        blueGoal.text = blue.ToString();
        yellowGoal.text = yellow.ToString();
    }
}
