using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_Melee_IdleState : Unit_Melee_BaseState
{
    public override void EnterState(Unit_Melee_StateManager unit)
    {
        unit._unitMeleeStates = Unit_Melee_StateManager.UnitMeleeStates.idle;
        if (unit.unitBehaviour.targets.Count == 0)
        {
            unit.unitBehaviour.InitUnit();
        }
    }

    public override void UpdateState(Unit_Melee_StateManager unit)
    {
        if (unit.unitBehaviour.targetPosition != null)
        {
            unit.ChangeState(unit.moveState);
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

    }

}
