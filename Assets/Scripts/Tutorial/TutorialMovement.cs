using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMovement : TutorialAbstract
{
    public override void EnterState(TutorialStateManager manager)
    {
        manager.playerInput.EnableMovement();
        // Play VO about movement
    }

    public override void ExitState(TutorialStateManager manager)
    {
        manager.SwitchStates(manager.tutorialCustomer);
    }

    public override void UpdateState(TutorialStateManager manager)
    {
        // Once Player has pushed one of the movement buttons, exit

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ExitState(manager);
        }
    }
}
