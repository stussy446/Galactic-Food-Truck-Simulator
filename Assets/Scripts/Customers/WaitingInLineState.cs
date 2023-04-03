using UnityEngine;

public class WaitingInLineState : CustomerBaseState
{

    /// <summary>
    /// Creates timer and initiates countdown for state switch to OrderingState
    /// </summary>

    private Vector3 customerPos, customerSpawnPos;
    private float currentTime;
    private float startingTime;
    private GameObject alienCustomer;
    private Vector3  orderPos;
    private float customerSpeed;


    public override void EnterState(CustomerStateManager customerState)
    {
        alienCustomer = customerState.alienCustomerPrefab;
        orderPos = customerState.orderingLocation.transform.position;
        customerPos = customerState.alienCustomerPrefab.transform.position;
        startingTime = customerState.customerCountdownStartTime;
        customerSpawnPos = customerState.customerResetLocation.transform.position;

        alienCustomer.transform.position = customerPos;

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
            Debug.Log(alienCustomer.transform.position);
            alienCustomer.transform.position = Vector3.MoveTowards(alienCustomer.transform.position, orderPos, customerSpeed * Time.deltaTime);
        }
    }

    public override void ExitState(CustomerStateManager customerState)
    {
        throw new System.NotImplementedException();
    }
}
