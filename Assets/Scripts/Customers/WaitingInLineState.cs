using UnityEngine;
using UnityEngine.Rendering;

public class WaitingInLineState : CustomerBaseState
{
    /// <summary>
    /// Creates timer and initiates countdown for state switch to OrderingState
    /// </summary>
    private Vector3 customerPos, customerSpawnPos;
    private float currentTime;
    private float startingTime;
    private GameObject alienCustomer;
    private float customerCountdownStartTime;

    public override void EnterState(CustomerStateManager customerState)
    {
        // Wait interval between customers is randomized between 5 and 10 seconds
        customerCountdownStartTime = Random.Range(5f, 10f);
        startingTime = customerCountdownStartTime;
        alienCustomer = customerState.customer.CustomerPrefab;
        currentTime = startingTime;
        customerPos = alienCustomer.transform.position;
        customerSpawnPos = customerState.CustomerResetLocation.transform.position;
        customerState.customer.SetUpCustomer(customerState.customer.GetRandomCustomer());

        if (customerPos != customerSpawnPos)
        {
            alienCustomer.transform.position = customerSpawnPos;
        }
        customerState.customer.OnCustomerEnter();
    }

    /// <summary>
    /// Starts countdown timer for customer arrival
    /// </summary>
    /// <param name="customerState"></param>
    public override void UpdateState(CustomerStateManager customerState)
    {
        currentTime = startingTime -= Time.deltaTime;
        if (currentTime <= 0)
        {
            ExitState(customerState);
        }
    }

    public override void ExitState(CustomerStateManager customerState)
    {
        customerState.SwitchState(customerState.OrderingState);

    }
}
