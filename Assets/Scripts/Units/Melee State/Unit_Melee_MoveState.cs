using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Unit_Melee_MoveState : Unit_Melee_BaseState
{

    public override void EnterState(Unit_Melee_StateManager unit)
    {
        unit._unitMeleeStates = Unit_Melee_StateManager.UnitMeleeStates.move;
        unit.unitBehaviour.isMoving = true;
        unit.unitBehaviour.animator.SetBool("IsMoving", true);
        unit.unitBehaviour.InitMovement();
    }

    public override void UpdateState(Unit_Melee_StateManager unit)
    {

        // CHECK IF MOVING TO TARGET BUT TARGET IS DEAD
        if (unit.unitBehaviour.targets.Count > 0)
        {
            if (unit.unitBehaviour.targets.All(e => e.isDead))
            {
                unit.ChangeState(unit.idleState);
            }
        }

        // CHECK IF REACH TARGET
        if (unit.unitBehaviour.targets.Count > 0)
        {
            if (Vector3.Distance(unit.transform.position, unit.unitBehaviour.targets[0].transform.position) <= unit.unitBehaviour.rangeOfAttack)
            { 
                unit.ChangeState(unit.attackState);
            }
        }

    }
    public override void ExitState(Unit_Melee_StateManager unit)
    {
        unit.unitBehaviour.animator.SetBool("IsMoving", false);
    }

}
