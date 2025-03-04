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
    [SerializeField] internal float rangeOfAttack;
    [SerializeField] internal int numOfTarget = 1;
    internal Vector3 targetPosition;

    public List<Unit> targets = new List<Unit>();

    internal bool isMoving;
}
