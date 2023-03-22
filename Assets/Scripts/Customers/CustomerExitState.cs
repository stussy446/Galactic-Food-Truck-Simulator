
using UnityEngine;

public class CustomerExitState : CustomerBaseState

{
    private GameObject alienCustomer;
    private Vector3 customerPos, exitPos;
    private float customerSpeed;
    public override void EnterState(CustomerStateManager customerState)
    {
        alienCustomer = customerState.alienCustomerPrefab;
       customerPos = customerState.alienCustomerPrefab.transform.position;
       exitPos = customerState.customerExitLocation.transform.position;
       customerSpeed = customerState.customerSpeed;

        alienCustomer.transform.position = customerPos;
    }

    public override void UpdateState(CustomerStateManager customerState)
    {
        if (alienCustomer.transform.position != exitPos)
        {
            alienCustomer.transform.position = Vector3.MoveTowards(alienCustomer.transform.position, exitPos, customerSpeed * Time.deltaTime);
        }

        if(alienCustomer.transform.position == exitPos)
        {
            customerState.OnCharacterExit();
        }
    }
}
