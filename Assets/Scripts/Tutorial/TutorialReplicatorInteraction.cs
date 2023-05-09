public class TutorialReplicatorInteraction : TutorialAbstract
{
    private const string CAN_INTERACT = "CanInteract";
    private const string DEFAULT = "Default";

    public override void EnterState(TutorialStateManager manager)
    {
        ActionList.OnDoneReplicatingFood += PlayerGaveCorrectOrder;

        manager.replicator.gameObject.SetActive(true);
    }

    public override void ExitState(TutorialStateManager manager)
    {
        ActionList.OnDoneReplicatingFood -= PlayerGaveCorrectOrder;

        manager.replicator.gameObject.SetActive(false);

        manager.SwitchStates(manager.tutorialButton);
    }

    public override void UpdateState(TutorialStateManager manager) { }

    private void PlayerGaveCorrectOrder(ActionType type)
    {
        ExitState(TutorialStateManager.Instance);
    }
}
