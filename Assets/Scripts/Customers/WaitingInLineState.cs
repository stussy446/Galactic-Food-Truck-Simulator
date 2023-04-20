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
        // TO DO:  set all the information of this instance to the scriptable objects values 

        customerCountdownStartTime = Random.Range(5f, 10f);
        startingTime = customerCountdownStartTime;
        alienCustomer = customerState.customer.CustomerPrefab;
        currentTime = startingTime;
        customerPos = alienCustomer.transform.position;
        customerSpawnPos = customerState.customerResetLocation.transform.position;
        customerState.customer.SetUpCustomer(customerState.customer.GetRandomCustomer());

        Debug.Log($"Customer Position is: {customerPos}, spawn pos is: {customerSpawnPos}");

        if (customerPos != customerSpawnPos)
        {
            alienCustomer.transform.position = customerSpawnPos;
        }
        customerState.customer.OnCustomerEnter();


        Debug.Log("JELLY ENTITY IS AWAITING IN CUE.");
    }

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
        customerState.SwitchState(customerState.orderingState);

    }
}
