using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Unit_Melee : Unit
{
    Coroutine coroutineMovement;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void InitUnit()
    {
        targetPosition = GameManager.Instance.playerBase.transform.position;
    }

    public void InitMovement()
    {
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
                transform.position = Vector3.Lerp(startPosition, target, (elapsedTime / duration));
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            transform.position = target;
        }
    }
    public void ChangeTargetPosition()
    {
        if (coroutineMovement != null)
        {
            StopCoroutine(coroutineMovement);
            coroutineMovement = null;
        }

        targetPosition = targets[0].transform.position;
    }


    public virtual void TakeDamage(float damageTaken)
    {
        health -= damageTaken;
    }

    public virtual void Death()
    {
        StopAllCoroutines();
        coroutineMovement = null;
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.GetComponent<Unit>())
        {
            if (!collision.GetComponent<Unit>().isEnemy)
            {
                if (targets.Count < numOfTarget)
                {
                    targets.Add(collision.gameObject.GetComponent<Unit>());
                    ChangeTargetPosition();
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
