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
    }

    public override void ExitState(StateManager manager)
    {
        MenuManager.Instance.ActivateMenu(MenuType.Start);
        manager.SwitchStates(manager.freeRoamingState);
    }

    public override void UpdateState(StateManager manager)
    {
        if (Input.GetKeyDown(KeyCode.Space) || orderManager.IsCorrect)
        {
            ExitState(manager);
        }
    }

    // TODO: create button click methods for interacting with the UI
}
