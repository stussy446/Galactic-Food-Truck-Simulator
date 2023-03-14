using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Game State for when user is simply walking around the environment.
/// </summary>
public class FreeRoamingState : StateAbstract
{
    private StateAbstract goToState;

    public override void EnterState(StateManager manager)
    {
        // TODO: User regains ability to move around and interact with the environment
    }

    public override void ExitState(StateManager manager)
    {       
        if (goToState == null) { return; }

        // Go to whichever state is set to goToState;
        manager.SwitchStates(goToState);
    }

    public override void UpdateState(StateManager manager)
    {
        // TODO: Handle player movement in here
        // TODO: Exit if one of the following happens
        //  - Customer arrives at the window
        //      - goToState = manager.receivingOrderState;
        //  - User clicks on Translator
        //      - goToState = manager.translationState;
        //  - User goes to the button to save the world
        //      - goToState = manager.pressingButtonState;
        //  - User interacts with Food Replicator
        //      - goToState = manager.fulfillingOrderState;
    }
}
