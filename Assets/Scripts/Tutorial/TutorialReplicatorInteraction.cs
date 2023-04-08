using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialReplicatorInteraction : TutorialAbstract
{
    private const string CAN_INTERACT = "CanInteract";
    private const string DEFAULT = "Default";

    public override void EnterState(TutorialStateManager manager)
    {
        ActionList.OnDoneReplicatingFood += PlayerGaveCorrectOrder;

        Debug.Log("We are here");
        manager.replicator.layer = LayerMask.NameToLayer(CAN_INTERACT);
        // VO Explaining the replicator

    }

    public override void ExitState(TutorialStateManager manager)
    {
        ActionList.OnDoneReplicatingFood -= PlayerGaveCorrectOrder;

        manager.SwitchStates(manager.tutorialButton);
    }

    public override void UpdateState(TutorialStateManager manager)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ExitState(manager);
        }
    }

    private void PlayerGaveCorrectOrder(ActionType type)
    {
        ExitState(TutorialStateManager.Instance);
    }
}
