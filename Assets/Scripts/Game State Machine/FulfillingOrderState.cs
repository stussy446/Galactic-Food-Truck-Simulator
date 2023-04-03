using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Game State for whenever user enters the food replicator UI.
/// </summary>
public class FulfillingOrderState : StateAbstract
{
    OrderManager orderManager;
    bool orderCorrect;

    public override void EnterState(StateManager manager)
    {
        orderManager = MonoBehaviour.FindObjectOfType<OrderManager>();
        manager.playerInputManager.DisableMovement();
        MenuManager.Instance.ActivateMenu(MenuType.EightItem);
        ActionList.OnEnteredFoodReplicator?.Invoke(ActionType.EnteredFoodReplicator);

        // TODO: Bring order screen to main screen (think Among Us task)
        manager.playerInputManager.GoToReplicatingPosition();

        ActionList.OnDoneReplicatingFood += ctx => orderCorrect = true;

    }

    public override void ExitState(StateManager manager)
    {
        MenuManager.Instance.ActivateMenu(MenuType.Start);
        orderCorrect = false;
        manager.SwitchStates(manager.freeRoamingState);
    }

    public override void UpdateState(StateManager manager)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ExitState(manager);
        }
        else if (orderCorrect)
        {
            ExitState(manager);
        }
    }

}
