using UnityEngine;

public class CustomerExitState : CustomerBaseState

{
    private GameObject alienCustomer;
    private Vector3 customerPos, exitPos;
    private float customerSpeed;
 
    /// <summary>
    /// Delivers order audio, checks for correct order
    /// </summary>
    /// <param name="customerState"></param>
    public override void EnterState(CustomerStateManager customerState)
    {
       //Intializing variables from CustomerStateManager
        alienCustomer = customerState.alienCustomerPrefab;
        customerPos = customerState.alienCustomerPrefab.transform.position;
        exitPos = customerState.customerExitLocation.transform.position;
        customerSpeed = customerState.customerSpeed;

        alienCustomer.transform.position = customerPos;

    }

    public override void UpdateState(CustomerStateManager customerState)
    {
        Debug.Log("JELLY ENTITY IS PLEASED AND EXPRESSES GRATITUDE. FAREWELL.");


        if (alienCustomer.transform.position != exitPos)
        {
            alienCustomer.transform.position = Vector3.MoveTowards(alienCustomer.transform.position, exitPos, customerSpeed * Time.deltaTime);
        }

        if(alienCustomer.transform.position == exitPos)
        {
            alienCustomer.transform.position = customerState.customerResetLocation.transform.position; 
            customerState.OnCharacterExit();
            ExitState(customerState);
        }
    }

    public override void ExitState(CustomerStateManager customerState)
    {
        customerState.SwitchState(customerState.waitingInLineState);
    }
}
