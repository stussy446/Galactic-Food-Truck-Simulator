using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTranslatorInteraction : TutorialAbstract
{
    private const string CAN_INTERACT = "CanInteract";
    private const string DEFAULT = "Default";
    public override void EnterState(TutorialStateManager manager)
    {
        manager.translator.layer = LayerMask.NameToLayer(CAN_INTERACT);
        // Play VO explaining the translator
    }

    public override void ExitState(TutorialStateManager manager)
    {
        manager.translator.layer = LayerMask.NameToLayer(DEFAULT);

        manager.SwitchStates(manager.tutorialReplicator);
    }

    public override void UpdateState(TutorialStateManager manager)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ExitState(manager);
        }
    }
}
