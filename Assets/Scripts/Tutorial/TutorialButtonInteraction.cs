using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialButtonInteraction : TutorialAbstract
{
    private const string CAN_INTERACT = "CanInteract";
    private const string DEFAULT = "Default";

    private float timer;

    public override void EnterState(TutorialStateManager manager)
    {
        ActionList.OnButtonPressed += PlayerPressedButton;

        manager.button.layer = LayerMask.NameToLayer(CAN_INTERACT);
        manager.button.GetComponentInChildren<SaveUniverseButton>().enabled = true;
        timer = 2f;
        // VO Explaining the button

    }

    public override void ExitState(TutorialStateManager manager)
    {
        ActionList.OnButtonPressed -= PlayerPressedButton;

        manager.button.layer = LayerMask.NameToLayer(DEFAULT);
        manager.SwitchStates(manager.tutorialEnd);

    }

    public override void UpdateState(TutorialStateManager manager)
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            manager.customer.gameObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ExitState(manager);
        }
    }

    private void PlayerPressedButton(ActionType type)
    {
        ExitState(TutorialStateManager.Instance);
    }
}
