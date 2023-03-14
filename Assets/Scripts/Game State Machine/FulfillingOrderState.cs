using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FulfillingOrderState : StateAbstract
{
    public override void EnterState(StateManager manager)
    {
        // TODO: Bring order screen to main screen (think Among Us task)
    }

    public override void ExitState(StateManager manager)
    {
        // Return to free roaming state
        manager.SwitchStates(manager.freeRoamingState);
    }

    public override void UpdateState(StateManager manager)
    {
        // TODO: Exit whenever user completes an order
    }

    // TODO: create button click methods for interacting with the UI
}
