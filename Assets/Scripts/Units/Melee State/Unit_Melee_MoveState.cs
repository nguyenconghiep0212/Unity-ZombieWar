using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_Melee_MoveState : Unit_Melee_BaseState
{
    
    public override void EnterState(Unit_Melee_StateManager unit)
    {
        unit._unitMeleeStates = Unit_Melee_StateManager.UnitMeleeStates.move;
        unit.unitBehaviour.isMoving = true;
        unit.unitBehaviour.InitMovement();
    }

    public override void UpdateState(Unit_Melee_StateManager unit)
    {
         
    }


}
