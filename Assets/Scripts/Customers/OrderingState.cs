using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderingState : CustomerBaseState
{
   // VoiceOverManager voiceOverManager;
    private GameObject alienCustomer;
    private Vector3 customerPos, orderPos;
    private float customerSpeed;


    public override void EnterState(CustomerStateManager customerState)
    {
        alienCustomer = customerState.alienCustomerPrefab;
        customerPos = customerState.alienCustomerPrefab.transform.position;
        orderPos = customerState.orderingLocation.transform.position;
        customerSpeed = customerState.customerSpeed;

        alienCustomer.transform.position = customerPos;

    }

    public override void UpdateState(CustomerStateManager customerState)
    {
     
        if(alienCustomer.transform.position != orderPos)
        {
            alienCustomer.transform.position = Vector3.MoveTowards(alienCustomer.transform.position, orderPos, customerSpeed * Time.deltaTime);
            AudioCustomerOrder();
            //TODO: connect voice clip
            //voiceOverManager.PlayAudioClip(ActionType.CustomerArrived);
        }

        if (Input.GetKeyDown(KeyCode.O) == true)
        {
            Debug.Log("JELLY ENTITY IS PLEASED AND EXPRESSES GRATITUDE. FAREWELL.");
       
            customerState.SwitchState(customerState.customerExitState);
        }
        else
        {
            //TODO: connect wrong order voice clip
            //send player back to Replicator
        }
    }

    private void AudioCustomerOrder()
    {
        Debug.Log("JELLY ENTITY WISHES TO PARTAKE OF THIS ESTABLISHMENT'S FINEST EXPEDIANT MEAL.");
    }
}
