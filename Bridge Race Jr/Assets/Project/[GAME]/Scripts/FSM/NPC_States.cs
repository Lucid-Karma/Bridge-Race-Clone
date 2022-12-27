using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NPC_States
{
    public abstract void EnterState(NPC fsm);
    public abstract void UpdateState(NPC fsm);
    public abstract void ExitState(NPC fsm);
}
