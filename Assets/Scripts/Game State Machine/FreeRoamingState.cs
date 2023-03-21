using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

/// <summary>
/// Game State for when user is simply walking around the environment.
/// </summary>
public class FreeRoamingState : StateAbstract
{
    private const string CAN_INTERACT = "CanInteract";

    private StateAbstract goToState;

    public override void EnterState(StateManager manager)
    {
        // TODO: User regains ability to move around and interact with the environment
        Debug.Log("Free Roaming State");
        AddRelevantListeners();
        manager.playerInputManager.EnableMovement();
    }

    public override void ExitState(StateManager manager)
    {       
        if (goToState == null) { return; }

        manager.playerInputManager.DisableMovement();

        RemoveRelevantListeners();

        // Go to whichever state is set to goToState;
        manager.SwitchStates(goToState);
    }

    public override void UpdateState(StateManager manager)
    {
        GameObject interactable = FindInteractableItem();
        if (interactable == null) { return; }
        //Debug.Log(interactable.name);
        if (Input.GetKeyDown(KeyCode.E))
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

        if (Physics.SphereCast(origin, radius, direction, out hit, detectionRange, LayerMask.GetMask(CAN_INTERACT)))
        {
            return hit.collider.gameObject;
        }
        return null;
    }

    /// <summary>
    /// Invokes action to switch state based on which object was interacted with
    /// </summary>
    /// <param name="obj"></param>
    private void OpenObjectInteraction(GameObject obj)
    {
        InteractionManager interaction = obj.GetComponent<InteractionManager>();
        ActionType interactionType = interaction.actionType;
        Debug.Log(interactionType.ToString());
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

    private void AddRelevantListeners()
    {
        ActionList.OnEnteredButtonPressing += SwitchStateListener;
        ActionList.OnEnteredTranslator += SwitchStateListener;
        ActionList.OnEnteredFoodReplicator += SwitchStateListener;
        ActionList.OnCustomerArrived += SwitchStateListener;
    }

    private void RemoveRelevantListeners()
    {
        ActionList.OnEnteredButtonPressing -= SwitchStateListener;
        ActionList.OnEnteredTranslator -= SwitchStateListener;
        ActionList.OnEnteredFoodReplicator -= SwitchStateListener;
        ActionList.OnCustomerArrived -= SwitchStateListener;
    }
}
