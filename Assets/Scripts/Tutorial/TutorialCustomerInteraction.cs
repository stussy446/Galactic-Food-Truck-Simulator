using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCustomerInteraction : TutorialAbstract
{
    public override void EnterState(TutorialStateManager manager)
    {
        ActionList.OnCustomerOrdered += PlayerInteractedWithCustomer;

        manager.customer.gameObject.SetActive(true);
    }

    public override void ExitState(TutorialStateManager manager)
    {
        ActionList.OnCustomerOrdered -= PlayerInteractedWithCustomer;
        manager.SwitchStates(manager.tutorialTranslator);

    }

    public override void UpdateState(TutorialStateManager manager)
    {
        
    }

    private void PlayerInteractedWithCustomer(ActionType actionType)
    {
        ExitState(TutorialStateManager.Instance);
    }
}
