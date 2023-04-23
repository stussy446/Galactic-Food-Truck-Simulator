public abstract class CustomerBaseState
{
    public abstract void UpdateState(CustomerStateManager customerState);
    public abstract void EnterState(CustomerStateManager customerState);
    public abstract void ExitState(CustomerStateManager customerState); 

}
