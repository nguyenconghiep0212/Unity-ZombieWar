using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{

    internal Animator animator;

    
    [SerializeField] internal bool isEnemy;
    [SerializeField] internal float maxHealth = 100;
    [SerializeField] internal float damage;
    [SerializeField] internal float moveSpeed;
    [SerializeField] internal float delayPerAttack = 1;
    [SerializeField] internal float rangeOfAttack;
    [SerializeField] internal int numOfTarget = 1;
    [SerializeField] internal Transform healthBarPosition;

    HealthBar healthBar;
    internal Vector3 targetPosition;
    internal float health;

    internal PlayerBase playerBase;

    public List<Unit> targets = new List<Unit>();
    public List<Unit> targetsInRange = new List<Unit>();


    internal bool isMoving;
    public bool isDead;
     
    public void InitHealthBar()
    {
        health = maxHealth;
        healthBar = Instantiate(GameManager.Instance.healthBarPrefab, healthBarPosition);
        healthBar.GetComponent<CanvasGroup>().alpha = 0;
    }
    public virtual void TakeDamage(float damageTaken)
    {
        healthBar.GetComponent<CanvasGroup>().alpha = 1;
        health -= damageTaken;
        float percentageHealthLeft = health / maxHealth;
        healthBar.UpdateHealthBar(percentageHealthLeft);
    }

    public virtual void Death()
    {
        isDead = true; 
    }
     
}
