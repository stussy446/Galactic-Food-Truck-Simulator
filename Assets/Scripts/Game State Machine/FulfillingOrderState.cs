using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// Game State for whenever user enters the food replicator UI.
/// </summary>
public class FulfillingOrderState : StateAbstract
{
    MenuManager menuManager;
    OrderManager orderManager;

    public override void EnterState(StateManager manager)
    {
        menuManager = MonoBehaviour.FindObjectOfType<MenuManager>();
        orderManager = MonoBehaviour.FindObjectOfType<OrderManager>(includeInactive: true);

        manager.playerInputManager.DisableMovement();

        Debug.Log("You are in the fulfilling order state!");
    }

    public override void ExitState(StateManager manager)
    {
        // TODO: Set replicator to original UI 
        // Return to free roaming state
        menuManager.ActivateMenu(MenuType.Start);
        manager.SwitchStates(manager.freeRoamingState);
    }

    public override void UpdateState(StateManager manager)
    {
        // TODO: Exit whenever user completes an order
        if (Input.GetKeyDown(KeyCode.Space) || orderManager.IsCorrectAnswer())
        {
            ExitState(manager);
        }
    }

}
