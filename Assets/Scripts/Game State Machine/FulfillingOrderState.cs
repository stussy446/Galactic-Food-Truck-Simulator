using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Game State for whenever user enters the food replicator UI.
/// </summary>
public class FulfillingOrderState : StateAbstract
{
    public override void EnterState(StateManager manager)
    {
        // TODO: Bring order screen to main screen (think Among Us task)
        Debug.Log("You are in the fulfilling order state!");
        manager.playerInputManager.GoToReplicatingPosition();
    }

    public override void ExitState(StateManager manager)
    {
        // TODO: Set replicator to original UI 
        // Return to free roaming state
        manager.SwitchStates(manager.freeRoamingState);
    }

    public override void UpdateState(StateManager manager)
    {
        // TODO: Exit whenever user completes an order
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ExitState(manager);
        }
    }

    // TODO: create button click methods for interacting with the UI
}
