/// <summary>
/// Common implementation of all concrete states.
/// </summary>
public abstract class StateAbstract
{
    public abstract void EnterState(StateManager manager);
    public abstract void UpdateState(StateManager manager);
    public abstract void ExitState(StateManager manager);
}
