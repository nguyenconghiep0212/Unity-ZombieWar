using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Image healthUI; 
    
    public void UpdateHealthBar(float percentageHealthLeft)
    {
        healthUI.fillAmount = percentageHealthLeft;
    }
}
