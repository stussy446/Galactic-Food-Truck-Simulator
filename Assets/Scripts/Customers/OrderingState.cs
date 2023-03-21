using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderingState : CustomerBaseState
{
    VoiceOverManager voiceOverManager;

    private bool orderFufilledCheck;
    private Vector3 customerPos, orderPos;
    private float customerSpeed;
    public override void EnterState(CustomerStateManager customerState)
    {
        orderFufilledCheck = customerState.correctOrderFufilled;
        customerPos = customerState.alienCustomerPrefab.transform.position;
        orderPos = customerState.orderingLocation.transform.position;
        customerSpeed = customerState.customerSpeed;

    }

    public override void UpdateState(CustomerStateManager customerState)
    {
     
        if(customerPos != orderPos)
        {
            customerPos = Vector3.MoveTowards(customerPos, orderPos, customerSpeed * Time.deltaTime);
            Debug.Log("THIS IS MY ORDER BEEP BOOP");
            //TODO: connect voice clip
            //voiceOverManager.PlayAudioClip(ActionType.CustomerArrived);
        }

        if (orderFufilledCheck)
        {
            Debug.Log("Thank you so much!");
       
            customerState.SwitchState(customerState.customerExitState);
        }
        else
        {
            //TODO: connect wrong order voice clip
            //send player back to Replicator
        }

        return;
        
    }

   

    //Destroy listeners
}
