
using UnityEngine;

public class CustomerExitState : CustomerBaseState

{
    private Vector3 customerPos, exitPos;
    private float customerSpeed;
    public override void EnterState(CustomerStateManager customerState)
    {
       customerPos = customerState.alienCustomerPrefab.transform.position;
       exitPos = customerState.customerExitLocation.transform.position;
       customerSpeed = customerState.customerSpeed;
    }

    public override void UpdateState(CustomerStateManager customerState)
    {
        if (customerPos != exitPos)
        {
            customerPos = Vector3.MoveTowards(customerPos, exitPos, customerSpeed * Time.deltaTime);
        }

        if(customerPos == exitPos)
        {
            customerState.OnCharacterExit();
        }
    }
}
