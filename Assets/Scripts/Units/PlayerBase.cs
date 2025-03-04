using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    public int Health
    {
        get { return GameManager.Instance.userData.baseHealth; }
        set
        {
            if (value < 0)
                GameManager.Instance.userData.baseHealth = 0; // Prevent negative health
            else
                GameManager.Instance.userData.baseHealth = value;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
