public class TutorialMovement : TutorialAbstract
{
    public override void EnterState(TutorialStateManager manager)
    {
        manager.playerInput.EnableMovement();
    }

    public override void ExitState(TutorialStateManager manager)
    {
        manager.SwitchStates(manager.tutorialCustomer);
    }

    public override void UpdateState(TutorialStateManager manager)
    {
        if (!manager.source.isPlaying)
        {
            ExitState(manager);
        }
    }
}
