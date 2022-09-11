using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AmmunitionScore : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public Text redScore;
    [SerializeField] public Text greenScore;
    [SerializeField] public Text blueScore;

    public void SetScores(int red, int green, int blue){
        redScore.text = red.ToString();
        greenScore.text = green.ToString();
        blueScore.text = blue.ToString();
    }
}
