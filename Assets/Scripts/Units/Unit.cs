using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{

    internal Animator animator;

    
    [SerializeField] internal bool isEnemy;
    [SerializeField] internal float health;
    [SerializeField] internal float damage;
    [SerializeField] internal float moveSpeed;
    [SerializeField] internal float delayPerAttack = 1;
    [SerializeField] internal float rangeOfAttack;
    [SerializeField] internal int numOfTarget = 1;
    public Vector3 targetPosition;

    public List<Unit> targets = new List<Unit>();
    public List<Unit> targetsInRange = new List<Unit>();


    internal bool isMoving;
    public bool isDead;

    public virtual void TakeDamage(float damageTaken)
    {
        health -= damageTaken;
    }

    public virtual void Death()
    {
        isDead = true; 
    }
     
}
