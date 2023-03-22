using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Game State for when user can only interact with the "Save the Universe" Button.
/// </summary>
public class PressingButtonState : StateAbstract
{
    private StateAbstract goToState;
    private SaveUniverseButton button;

    public override void EnterState(StateManager manager)
    {
        Debug.Log("Pressing Button State");
        button = MonoBehaviour.FindObjectOfType<SaveUniverseButton>();
        button.gameObject.GetComponent<Collider>().enabled = true;
        // TODO: Bring button to save the universe to the screen (Think Among Us task)
    }

    public override void ExitState(StateManager manager)
    {
        if (goToState == null) { return; }
        button.gameObject.GetComponent<Collider>().enabled = false;
        // Go back to free roaming state
        manager.SwitchStates(goToState);
    }

    public override void UpdateState(StateManager manager)
    {
        // TODO: Exit state when user presses to leave button area or Customer shows up
        //  - if user leaves button pressing area
        //      - goToState = manager.freeRoamingState;
        //  - if customer shows up
        //      - goToState = manager.receivingOrderState;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            goToState = manager.freeRoamingState;
            ExitState(manager);
        }
    }
}
