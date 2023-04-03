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
        // Gets reference to orderManager
        orderManager = MonoBehaviour.FindObjectOfType<OrderManager>();
        
        // Activates Replicator menu
        MenuManager.Instance.ActivateMenu(MenuType.EightItem);
        
        // Sets player position to be in front of replicator
        manager.playerInputManager.GoToReplicatingPosition();

        // Calls action once order is correctly fulfilled
        ActionList.OnDoneReplicatingFood += ctx => orderCorrect = true;

    }

    public override void ExitState(StateManager manager)
    {
        // Sets replicator menu to original view
        MenuManager.Instance.ActivateMenu(MenuType.Start);

        orderCorrect = false;
        manager.SwitchStates(manager.freeRoamingState);
    }

    public override void UpdateState(StateManager manager)
    {
        if (Input.GetKeyDown(KeyCode.Space) || orderCorrect)
        {
            ExitState(manager);
        }
    }

}
