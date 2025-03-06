using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_Melee_AttackState : Unit_Melee_BaseState
{
    public override void EnterState(Unit_Melee_StateManager unit)
    {
        unit._unitMeleeStates = Unit_Melee_StateManager.UnitMeleeStates.attack;
        unit.unitBehaviour.Attack();
    }

    public override void UpdateState(Unit_Melee_StateManager unit)
    {

        if (unit.unitBehaviour.targets.Count == 0)
        {
            unit.ChangeState(unit.idleState);
        }

    }

    public override void ExitState(Unit_Melee_StateManager unit)
    {

    }
}
