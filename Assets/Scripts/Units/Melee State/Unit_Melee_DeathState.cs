using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_Melee_DeathState : Unit_Melee_BaseState
{
    public override void EnterState(Unit_Melee_StateManager unit)
    {
        unit._unitMeleeStates = Unit_Melee_StateManager.UnitMeleeStates.death;

    }

    public override void UpdateState(Unit_Melee_StateManager unit)
    {
    }


}
