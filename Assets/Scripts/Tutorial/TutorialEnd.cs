public class TutorialEnd : TutorialAbstract
{
    public override void EnterState(TutorialStateManager manager) { }

    public override void ExitState(TutorialStateManager manager) { }

    public override void UpdateState(TutorialStateManager manager)
    {
        if (!manager.source.isPlaying) 
        {
            manager.LoadGame();
        }
    }
}
