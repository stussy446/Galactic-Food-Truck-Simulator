using UnityEngine;

public class WaitingInLineState : CustomerBaseState
{

    /// <summary>
    /// Creates timer and initiates countdown for state switch to OrderingState
    /// </summary>

    private Vector3 customerPos, customerSpawnPos;

    private float currentTime = 0f;
    private float startingTime = 5f;


    public override void EnterState(CustomerStateManager customerState)
    {
        customerPos = customerState.alienCustomerPrefab.transform.position;
        customerSpawnPos = customerState.customerResetLocation.transform.position;

        if (customerPos != customerSpawnPos)
        {
            customerPos = customerSpawnPos;
        }
        Debug.Log("I am waiting in line!!!");
    }


    public override void UpdateState(CustomerStateManager customerState)
    {
        currentTime = startingTime -= 1 * Time.deltaTime;
        if(currentTime <= 0)
        {
            customerState.SwitchState(customerState.orderingState);
        }
    }

}
