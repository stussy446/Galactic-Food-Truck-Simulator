using UnityEngine;

/// <summary>
/// Game State for whenever a new customer pops up.
/// </summary>
public class ReceivingOrderState : StateAbstract
{
    public override void EnterState(StateManager manager) { }
    public override void UpdateState(StateManager manager) { }

    public override void ExitState(StateManager manager)
    {
        // Go back to free roaming state
        manager.SwitchStates(manager.freeRoamingState);
    }
}
