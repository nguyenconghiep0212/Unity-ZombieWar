using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_Melee_IdleState : Unit_Melee_BaseState
{
    public override void EnterState(Unit_Melee_StateManager unit)
    {
        unit._unitMeleeStates = Unit_Melee_StateManager.UnitMeleeStates.idle;
        unit.unitBehaviour.InitUnit();
    }

    public override void UpdateState(Unit_Melee_StateManager unit)
    {
        if (unit.unitBehaviour.targetPosition != null)
        {
            unit.ChangeState(unit.moveState);
        }
    }


}
