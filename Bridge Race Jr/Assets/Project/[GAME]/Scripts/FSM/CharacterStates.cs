using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterStates
{
    public abstract void EnterState(CharacterBase fsm);
    public abstract void UpdateState(CharacterBase fsm);
    public abstract void ExitState(CharacterBase fsm);
}
