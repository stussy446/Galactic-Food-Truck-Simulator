using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Game State for whenever user enters the food replicator UI.
/// </summary>
public class FulfillingOrderState : StateAbstract
{
    OrderManager orderManager;

    public override void EnterState(StateManager manager)
    {
        orderManager = MonoBehaviour.FindObjectOfType<OrderManager>();
        manager.playerInputManager.DisableMovement();
        MenuManager.Instance.ActivateMenu(MenuType.EightItem);
        ActionList.OnEnteredFoodReplicator?.Invoke(ActionType.EnteredFoodReplicator);

        // TODO: Bring order screen to main screen (think Among Us task)
        Debug.Log("You are in the fulfilling order state!");
        manager.playerInputManager.GoToReplicatingPosition();
    }

    public override void ExitState(StateManager manager)
    {
        MenuManager.Instance.ActivateMenu(MenuType.Start);
        ActionList.OnDoneReplicatingFood?.Invoke(ActionType.DoneReplicatingFood);
        manager.SwitchStates(manager.freeRoamingState);
    }

    public override void UpdateState(StateManager manager)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ExitState(manager);
        }
        else if (orderManager.IsCorrect)
        {
            Debug.Log("Correct, well done!");
            ExitState(manager);
        }
    }

    // TODO: create button click methods for interacting with the UI
}
