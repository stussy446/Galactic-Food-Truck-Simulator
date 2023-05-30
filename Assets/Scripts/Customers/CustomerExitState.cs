using UnityEngine;

public class CustomerExitState : CustomerBaseState
{
    private GameObject alienCustomer;
    private Vector3 customerPos, exitPos;
    private float customerSpeed;
 
    /// <summary>
    /// 1. Moves customer toward exit position 
    /// 2. Resets position for the next customer
    /// 3. Destroys current customer model on the prefab
    /// </summary>
    /// <param name="customerState"></param>
    public override void EnterState(CustomerStateManager customerState)
    {
       //Intializing variables from CustomerStateManager
        alienCustomer = customerState.customer.CustomerPrefab;
        customerPos = alienCustomer.transform.position;
        exitPos = customerState.CustomerExitLocation.transform.position;
        customerSpeed = customerState.customer.CustomerSpeed;

        alienCustomer.transform.position = customerPos;

    }

    /// <summary>
    /// Moves toward exit and upon reaching the exit position, resets customer position to waiting in line
    /// </summary>
    /// <param name="customerState"></param>
    public override void UpdateState(CustomerStateManager customerState)
    {
        if (alienCustomer.transform.position != exitPos)
        {
            alienCustomer.transform.position = Vector3.MoveTowards(alienCustomer.transform.position, exitPos, customerSpeed * Time.deltaTime);
        }

        if(alienCustomer.transform.position == exitPos)
        {
            ActionList.OnCustomerLeft(ActionType.CustomerLeft);
            alienCustomer.transform.position = customerState.CustomerResetLocation.transform.position; 
            customerState.customer.OnCharacterExit();
            ExitState(customerState);
        }
    }

    /// <summary>
    /// Removes current model on customer in preparation for the next one
    /// </summary>
    /// <param name="customerState"></param>
    public override void ExitState(CustomerStateManager customerState)
    {
        customerState.customer.DestroyModel();
        customerState.SwitchState(customerState.WaitingInLineState);
    }

}
