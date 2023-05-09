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
        // Find the button in the hierarchy
        button = MonoBehaviour.FindObjectOfType<SaveUniverseButton>();

        // Set button to be interactable
        button.gameObject.GetComponent<Collider>().enabled = true;

        // Set player position to be right in front of button table
        manager.playerInputManager.GoToButtonPosition();
        
    }

    public override void ExitState(StateManager manager)
    {
        if (goToState == null) { return; }

        // Set button to not interactable
        button.gameObject.GetComponent<Collider>().enabled = false;

        // Go back to state based on goToState
        manager.SwitchStates(goToState);
    }

    public override void UpdateState(StateManager manager)
    {
        // TODO: Logic for when customer arrives, also exit state
        if (Input.GetKeyDown(KeyCode.Space))
        {
            goToState = manager.freeRoamingState;
            ExitState(manager);
        }
    }
}
