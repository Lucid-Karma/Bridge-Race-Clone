using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : NPC_States
{
    public override void EnterState(NPC fsm)
    {
        Debug.Log("Patroling");
        
        fsm.StartCoroutine(fsm.BuildWait(fsm.GetBuidTime())); 
    }

    public override void UpdateState(NPC fsm)
    {
        if(fsm.executingState == ExecutingState.PATROL)
        {
            fsm.Move();
            fsm.rb.MovePosition(fsm.gameObject.transform.position + (fsm.gameObject.transform.forward * fsm.moveSpeed * Time.fixedDeltaTime));
        }
        else   ExitState(fsm);
        
    }

    public override void ExitState(NPC fsm)
    {
        if(fsm.executingState == ExecutingState.BEAR)
        {
            fsm.SwitchState(fsm.bearState);
        }
        // else if(fsm.executingState == ExecutingState.OUTRUN)
        // {
        //     fsm.SwitchState(fsm.outRunningState);
        // }
    }
}
