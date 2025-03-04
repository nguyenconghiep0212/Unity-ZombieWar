using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Unit_Melee_StateManager : MonoBehaviour
{
    internal Unit_Melee unitBehaviour;

     Unit_Melee_BaseState curentState;
    internal Unit_Melee_IdleState idleState = new Unit_Melee_IdleState();
    internal Unit_Melee_MoveState moveState = new Unit_Melee_MoveState();
    internal Unit_Melee_AttackState attackState = new Unit_Melee_AttackState();
    internal Unit_Melee_DeathState deathState = new Unit_Melee_DeathState();

    public UnitMeleeStates _unitMeleeStates;
    public enum UnitMeleeStates
    {
        idle, move, attack, death
    }
    void Start()
    {
        unitBehaviour = GetComponent<Unit_Melee>();

        curentState = idleState;
        curentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        curentState.UpdateState(this);
    }

    internal void ChangeState(Unit_Melee_BaseState state)
    {
        if (state != curentState)
        {
            curentState = state;
            state.EnterState(this);
        }
    }
}
