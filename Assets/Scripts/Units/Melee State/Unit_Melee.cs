using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Unit_Melee : Unit
{
    Coroutine coroutineMovement;
    internal Unit_Melee_StateManager unitMeleeStateManager;

    private void Start()
    {
        unitMeleeStateManager = GetComponent<Unit_Melee_StateManager>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isDead)
        {
            Die();
        }
    }

    public void InitUnit()
    {
        CheckTargetToAttack();
    }

    #region ---- || MOVE || ----
    public void CheckTargetToAttack()
    {
        FlushTargetList();
        if (targetsInRange.Count > 0)
        {
            for (int i = 0; i < targetsInRange.Count; i++)
            {
                if (targets.Count == numOfTarget)
                {
                    break;
                }
                targets.Add(targetsInRange[i]);
            }
            foreach (Unit target in targets)
            {
                if (targetsInRange.Contains(target))
                    targetsInRange.Remove(target);
            }
            targetPosition = targets[0].transform.position;
        }
        else
        {
            if (isEnemy)
                targetPosition = GameManager.Instance.playerBase.transform.position;
            else
                targetPosition = PlayerManager.Instance.holdingLine.position;
        }

        ChangeTargetPosition();
    }
    public void InitMovement()
    {
        StopMoving();

        float distance = Vector3.Distance(transform.position, targetPosition);
        float duration = distance / moveSpeed;
        if (transform.position.x > targetPosition.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        coroutineMovement = StartCoroutine(MoveToPosition(targetPosition, duration));

        IEnumerator MoveToPosition(Vector3 target, float duration)
        {
            isMoving = true;
            Vector3 startPosition = transform.position;
            float elapsedTime = 0;

            while (elapsedTime < duration)
            {
                if (!isMoving)
                {
                    break;
                }
                transform.position = Vector3.Lerp(startPosition, target, (elapsedTime / duration));
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            transform.position = target;
        }
    }
    public void ChangeTargetPosition()
    {
        StopMoving();
        InitMovement();
    }

    public void StopMoving()
    {
        isMoving = false;
        if (coroutineMovement != null)
        {
            StopCoroutine(coroutineMovement);
            coroutineMovement = null;
        }
    }
    #endregion

    #region ---- || ATTACK || ----
    public void Attack()
    {
        StopMoving();

        StartCoroutine(AttackCoroutine());
        IEnumerator AttackCoroutine()
        {
            yield return new WaitForSeconds(delayPerAttack);
            animator.SetTrigger("Attack");
        }
    }
    public void DealDamage()
    {
        foreach (Unit unit in targets)
        {
            unit.TakeDamage(damage);
            if (unit.health <= 0)
            {
                unit.Death();
            }
        }
        FlushTargetList();
        FinishAttack();
    }
    public void FinishAttack()
    {
        unitMeleeStateManager.ChangeState(unitMeleeStateManager.idleState);
    }
    #endregion
    void FlushTargetList()
    {
        if (isEnemy)
            EnemyMamanger.Instance.FlushEnemyTarget();
        else
            PlayerManager.Instance.FlushUnitTarget();
    }
    public void Die()
    {
        if (isEnemy)
            EnemyMamanger.Instance.KillThisUnit(this);
        else
            PlayerManager.Instance.KillThisUnit(this);

        StopAllCoroutines();
        coroutineMovement = null;

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.GetComponent<Unit>())
        {

            if (isEnemy)
            {
                if (!collision.GetComponent<Unit>().isEnemy)
                {
                    if (!targetsInRange.Contains(collision.GetComponent<Unit>()))
                    {
                        targetsInRange.Add(collision.gameObject.GetComponent<Unit>());
                        CheckTargetToAttack();
                    }
                }
            }
            else
            {
                if (collision.GetComponent<Unit>().isEnemy)
                {
                    if (!targetsInRange.Contains(collision.GetComponent<Unit>()))
                    {
                        targetsInRange.Add(collision.gameObject.GetComponent<Unit>());
                        CheckTargetToAttack();
                    }
                }
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangeOfAttack);
    }
}
