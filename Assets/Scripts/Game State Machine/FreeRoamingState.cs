using UnityEngine;

/// <summary>
/// Game State for when user is simply walking around the environment.
/// </summary>
public class FreeRoamingState : StateAbstract
{
    private const string CAN_INTERACT = "CanInteract";

    private StateAbstract goToState;
    private TranslatorFunction translator;


    public override void EnterState(StateManager manager)
    {   
        // Add listeners to actions that allow user to leave this state
        AddRelevantListeners();

        // Find the translator in the scene
        translator = MonoBehaviour.FindObjectOfType<TranslatorFunction>();

        // Set the translator dial to interactable by disabling the translator's collider
        translator.gameObject.GetComponent<Collider>().enabled = true;

        // User regains ability to move around and isInteracting with the environment
        manager.playerInputManager.EnableMovement();

        // Set exit interaction feedback
        manager.exitInteractFeedback.SetActive(false);

        // Sets replicator menu to original view
        if (MenuManager.Instance != null)
        {
            MenuManager.Instance.ActivateMenu(MenuType.Start);
        }
    }

    public override void ExitState(StateManager manager)
    {
        // Checks to make sure we have a state to go to
        if (goToState == null) { return; }

        // Disables player movement while out of this state
        manager.playerInputManager.DisableMovement(true);

        // Remove all the listeners
        RemoveRelevantListeners();

        // Turn off the interact UI element
        ToggleInteractFeedback(false);

        // Set exit interaction feedback
        manager.exitInteractFeedback.SetActive(true);

        

        // Go to whichever state is set to goToState;
        manager.SwitchStates(goToState);
    }

    public override void UpdateState(StateManager manager)
    {
        // Identify if there is an interactable item
        InteractionManager interactable = FindInteractableItem();

        if (interactable == null) { return; }

        // Checks to see if user has pressed the interact key and interacts with
        // that object.
        if (manager.playerInputManager.IsInteracting)
        {
            interactable.Interact();
            manager.playerInputManager.IsInteracting = false;
        }
    }

    /// <summary>
    /// Listens to whenever user clicks to leave FreeRoamingState
    /// </summary>
    /// <param name="type"></param>
    private void SwitchStateListener(ActionType type)
    {
        //Switch case based on type to figure out which state will be the goToState
        switch (type)
        {
            case ActionType.EnteredButtonPressing:
                goToState = StateManager.instance.pressingButtonState;
                break;
            case ActionType.EnteredTranslator:
                goToState = StateManager.instance.translationState;
                break;
            case ActionType.EnteredFoodReplicator:
                goToState = StateManager.instance.fulfillingOrderState;
                break;
        }

        // Exit Free romaing state to the state that was passed in by the action
        ExitState(StateManager.instance);
    }

    /// <summary>
    /// Sphere sweep to identify if there is an interactable item in range
    /// </summary>
    /// <returns></returns>
    private InteractionManager FindInteractableItem()
    {
        RaycastHit hit;
        Vector3 origin = Camera.main.transform.position;
        Vector3 direction = Camera.main.transform.forward;
        float radius = 1f;
        float detectionRange = 3f;

        // Cast a sphere that collides with the CanInteract layer
        if (Physics.SphereCast(origin, radius, direction, out hit, detectionRange, LayerMask.GetMask(CAN_INTERACT)))
        {
            ToggleInteractFeedback(true);
            return hit.collider.gameObject.GetComponent<InteractionManager>();
        }
        ToggleInteractFeedback(false);
        return null;
    }


    /// <summary>
    /// Sets the Interact UI element to active or inactive
    /// </summary>
    /// <param name="toggle"></param>
    private void ToggleInteractFeedback(bool toggle)
    {
        StateManager.instance.interactFeedback.gameObject.SetActive(toggle);
    }

    private void AddRelevantListeners()
    {
        ActionList.OnEnteredButtonPressing += SwitchStateListener;
        ActionList.OnEnteredTranslator += SwitchStateListener;
        ActionList.OnEnteredFoodReplicator += SwitchStateListener;
    }

    private void RemoveRelevantListeners()
    {
        ActionList.OnEnteredButtonPressing -= SwitchStateListener;
        ActionList.OnEnteredTranslator -= SwitchStateListener;
        ActionList.OnEnteredFoodReplicator -= SwitchStateListener;
    }
}
