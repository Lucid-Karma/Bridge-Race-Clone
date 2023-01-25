using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearState : NPC_States
{
    public override void EnterState(NPC fsm)
    {
        Debug.Log("Bearing");

        fsm.stairStep = fsm.GetList().Count;
    }

    public override void UpdateState(NPC fsm)
    {
        if (fsm.executingState == ExecutingState.BEAR)
        {
            if(fsm.GetList().Count != 0)
                fsm.MoveToBridge();
            else if(fsm.GetList().Count == 0)
            {
                fsm.LeaveBridge();
            }

            fsm.rb.MovePosition(fsm.gameObject.transform.position + (fsm.gameObject.transform.forward * fsm.moveSpeed * Time.fixedDeltaTime));
        }
        else   ExitState(fsm);

        
    }

    public override void ExitState(NPC fsm)
    {
        if(fsm.executingState == ExecutingState.PATROL)
        {
            fsm.SwitchState(fsm.patrolState);
        }
        // else if(fsm.executingState == ExecutingState.OUTRUN)
        // {
        //     fsm.SwitchState(fsm.outRunningState);
        // }
    }
}
