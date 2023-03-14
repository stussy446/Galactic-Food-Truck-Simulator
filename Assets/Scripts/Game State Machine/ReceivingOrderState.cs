using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceivingOrderState : StateAbstract
{
    public override void EnterState(StateManager manager)
    {
        // TODO: Bring user's attention to the window
    }

    public override void ExitState(StateManager manager)
    {
        // Go back to free roaming state
        manager.SwitchStates(manager.freeRoamingState);
    }

    public override void UpdateState(StateManager manager)
    {
        // TODO: Exit once customer is done placing order
    }
}
