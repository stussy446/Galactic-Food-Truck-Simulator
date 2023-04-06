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
        // TO DO:  set all the information of this instance to the scriptable objects values 

        startingTime = customerState.customerCountdownStartTime;
        currentTime = startingTime;
        customerPos = customerState.alienCustomerPrefab.transform.position;
        customerSpawnPos = customerState.customerResetLocation.transform.position;
        customerState.customer.SetUpCustomer(customerState.customer.GetRandomCustomer());

        Debug.Log($"Customer Position is: {customerPos}, spawn pos is: {customerSpawnPos}");

        if (customerPos != customerSpawnPos)
        {
            customerState.alienCustomerPrefab.transform.position = customerSpawnPos;
        }
        customerState.OnCustomerEnter();
        //customerState.alienCustomerPrefab.SetActive(true);

        
        Debug.Log("JELLY ENTITY IS AWAITING IN CUE.");
    }

    public override void UpdateState(CustomerStateManager customerState)
    {
        currentTime = startingTime -= Time.deltaTime;
        if(currentTime <= 0)
        {
            ExitState(customerState);
        }
    }

    public override void ExitState(CustomerStateManager customerState)
    {
        customerState.SwitchState(customerState.orderingState);

    }
}
