using UnityEngine;

public class WaitingInLineState : CustomerBaseState
{

    /// <summary>
    /// Creates timer and initiates countdown for state switch to OrderingState
    /// </summary>

    private Vector3 customerPos, customerSpawnPos;
    private float currentTime;
    private float startingTime;


    public override void EnterState(CustomerStateManager customerState)
    {
        startingTime = customerState.customerCountdownStartTime;
        customerPos = customerState.alienCustomerPrefab.transform.position;
        customerSpawnPos = customerState.customerResetLocation.transform.position;

        if (customerPos != customerSpawnPos)
        {
            customerPos = customerSpawnPos;
        }

        Debug.Log("JELLY ENTITY IS AWAITING IN CUE.");
    }

    public override void UpdateState(CustomerStateManager customerState)
    {
        currentTime = startingTime -= 1 * Time.deltaTime;
        if(currentTime <= 0)
        {
            customerState.SwitchState(customerState.orderingState);
        }
    }

    public override void ExitState(CustomerStateManager customerState)
    {
        throw new System.NotImplementedException();
    }
}
