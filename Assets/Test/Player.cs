using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//for testing HUD components
public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public AmmunitionScore ammunitionScore;
    public int startScore = 0;
    public int redScore;
    public int greenScore;
    public int blueScore;
    // Start is called before the first frame update
    void Start()
    {
        redScore = startScore;
        greenScore = startScore;
        blueScore = startScore;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        ammunitionScore.SetScores(redScore, greenScore, blueScore);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
            GetScores();
        }
    }
                                  
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    void GetScores(){
        ammunitionScore.SetScores(++redScore, ++greenScore, ++blueScore);
    }
}
