using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildState : CharacterStates
{
    public override void EnterState(CharacterBase fsm)
    {
        Debug.Log("Building");
    }

    public override void UpdateState(CharacterBase fsm)
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

        //Debug.Log("making a stair");
    }

    public override void ExitState(CharacterBase fsm)
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
