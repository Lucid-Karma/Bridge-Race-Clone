using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : NPC_States
{
    public override void EnterState(NPC fsm)
    {
        Debug.Log("Patroling");
    }

    public override void UpdateState(NPC fsm)
    {
        // if (fsm.executingState == ExecutingState.OUTIDLE)
        // {
        //     fsm.animator.SetBool("isOutIdle", true);
        //     fsm.animator.SetBool("isOutRunning", false);
        //     fsm.animator.SetBool("isInRunning", false);
        //     fsm.animator.SetBool("isInIdle", false);
        // }
        // else
        //     ExitState(fsm);
        
    }

    public override void ExitState(NPC fsm)
    {
        // if(fsm.executingState == ExecutingState.INRUN)
        // {
        //     fsm.SwitchState(fsm.inRunningState);
        // }
        // else if(fsm.executingState == ExecutingState.OUTRUN)
        // {
        //     fsm.SwitchState(fsm.outRunningState);
        // }
    }
}
