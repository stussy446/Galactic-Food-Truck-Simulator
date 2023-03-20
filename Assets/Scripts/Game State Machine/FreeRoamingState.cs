using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        Debug.Log("Free Roaming State");
        AddRelevantListeners();
    }

    public override void ExitState(StateManager manager)
    {       
        if (goToState == null) { return; }

        RemoveRelevantListeners();

        // Go to whichever state is set to goToState;
        manager.SwitchStates(goToState);
    }

    public override void UpdateState(StateManager manager)
    {
        // No need to update as this will be event based
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
            case ActionType.ButtonPressed:
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
