using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderingState : CustomerBaseState
{

 
    VoiceOverManager voiceOverManager;

    private bool orderFufilledCheck;
    private Transform customerPos;
    private Vector3 orderPos;
    private float customerSpeed;
    public override void EnterState(CustomerStateManager customerState)
    {
        //-----------Attempting to intialize references to other scripts to gain access to variable info---
        MollyTempSceneManager tempSceneManager = new MollyTempSceneManager();
        CustomerStateManager customerStateManager = new CustomerStateManager();


        orderFufilledCheck = tempSceneManager.correctOrderFufilled;
        customerPos = customerStateManager.alienCustomerPrefab;
        orderPos = customerStateManager.orderingPosVector; //run into null exception here
        customerSpeed = customerStateManager.customerSpeed;

        //--------------------------------------------------------------------


        Debug.Log("THIS IS MY ORDER BEEP BOOP");


        //TODO: for later
        // find order location
        // run entering animation
        //when arrives at ordering position, play voice clip
        //voiceOverManager.PlayAudioClip(ActionType.CustomerArrived);

    }

    public override void UpdateState(CustomerStateManager customerState)
    {

        //------------Checking customer prefabs current position to see if equal to orderlocation, if not: move toward---
     
        if(customerPos.position != orderPos)
        {
            customerPos.position = Vector3.MoveTowards(customerPos.position, orderPos, customerSpeed * Time.deltaTime);
        }


        //----------------------------------------
        
        if (orderFufilledCheck)
        {
            Debug.Log("Thank you so much!");
       
            customerState.SwitchState(customerState.customerExitState);
        }
        else
        {
            //play wrong order VO
            //send player back to Replicator
        }

        return;
        
    }

   

    //Destroy listeners
}
