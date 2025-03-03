using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{ 

    protected Animator animator;

    [SerializeField] internal float health;
    [SerializeField] internal float damage;
    [SerializeField] internal int numOfTarget = 1;
    internal Vector3 targetPosition;

    List<Unit> targets = new List<Unit>();

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public virtual void Attack()
    {

    } 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (targets.Count < 1)
            {
                targets.Add(collision.gameObject.GetComponent<Unit>());
            }
        }
    }

    public virtual void TakeDamage(float damageTaken)
    {
        health -= damageTaken;
    }

    public virtual void Death()
    {
        Destroy(gameObject);
    }
}
