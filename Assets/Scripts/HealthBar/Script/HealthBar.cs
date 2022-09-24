using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//ref: https://www.youtube.com/watch?v=BLfNP4Sc_iA&t=518s
public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxHealth(int health)
    {
        
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {   Debug.Log("Inside health broooo!!!!");
        slider.value = health;

        //! if slider.value  <= 0: trigger the game over HUD
    }
}
