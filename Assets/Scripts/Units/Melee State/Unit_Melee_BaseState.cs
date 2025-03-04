 
using UnityEngine;

public abstract class Unit_Melee_BaseState  
{
    public abstract void EnterState(Unit_Melee_StateManager unit);
    public abstract void UpdateState(Unit_Melee_StateManager unit);
}   
