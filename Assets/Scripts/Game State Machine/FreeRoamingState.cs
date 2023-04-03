using UnityEngine;

/// <summary>
/// Game State for when user is simply walking around the environment.
/// </summary>
public class FreeRoamingState : StateAbstract
{
    private const string CAN_INTERACT = "CanInteract";

    private StateAbstract goToState;

    public override void EnterState(StateManager manager)
    {   
        // Add listeners to actions that allow user to leave this state
        AddRelevantListeners();

        // User regains ability to move around and isInteracting with the environment
        manager.playerInputManager.EnableMovement();
    }

    public override void ExitState(StateManager manager)
    {
        // Checks to make sure we have a state to go to
        if (goToState == null) { return; }

        // Disables player movement while out of this state
        manager.playerInputManager.DisableMovement();

        // Remove all the listeners
        RemoveRelevantListeners();

        // Turn off the interact UI element
        ToggleInteractFeedback(false);

        // Go to whichever state is set to goToState;
        manager.SwitchStates(goToState);
    }

    public override void UpdateState(StateManager manager)
    {
        // Identify if there is an interactable item
        GameObject interactable = FindInteractableItem();

        if (interactable == null) { return; }

        // Checks to see if user has pressed the interact key and interacts with
        // that object.
        if (manager.playerInputManager.IsInteracting)
        {
            OpenObjectInteraction(interactable);
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
            case ActionType.CustomerArrived:
                goToState = StateManager.instance.receivingOrderState;
                break;
        }

        // Exit Free romaing state to the state that was passed in by the action
        ExitState(StateManager.instance);
    }

    /// <summary>
    /// Sphere sweep to identify if there is an interactable item in range
    /// </summary>
    /// <returns></returns>
    private GameObject FindInteractableItem()
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
            return hit.collider.gameObject;
        }
        ToggleInteractFeedback(false);
        return null;
    }

    /// <summary>
    /// Invokes action to switch state based on which object was interacted with
    /// </summary>
    /// <param name="obj"></param>
    private void OpenObjectInteraction(GameObject obj)
    {
        // Find the interaction type on the GameObject
        InteractionManager interaction = obj.GetComponent<InteractionManager>();
        ActionType interactionType = interaction.actionType;

        // Invoke the correct action
        switch (interactionType)
        {
            case ActionType.EnteredButtonPressing:
                ActionList.OnEnteredButtonPressing?.Invoke(ActionType.EnteredButtonPressing);
                break;
            case ActionType.EnteredTranslator:
                ActionList.OnEnteredTranslator?.Invoke(ActionType.EnteredTranslator);
                break;
            case ActionType.EnteredFoodReplicator:
                ActionList.OnEnteredFoodReplicator?.Invoke(ActionType.EnteredFoodReplicator);
                break;
        }
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
        ActionList.OnCustomerArrived += SwitchStateListener;
    }

    private void RemoveRelevantListeners()
    {
        ActionList.OnEnteredButtonPressing += SwitchStateListener;
        ActionList.OnEnteredTranslator -= SwitchStateListener;
        ActionList.OnEnteredFoodReplicator -= SwitchStateListener;
        ActionList.OnCustomerArrived -= SwitchStateListener;
    }
}
