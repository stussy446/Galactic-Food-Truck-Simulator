using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class CustomerStateManager : MonoBehaviour
{
    //this script is attached to the customer prefab that is instatiated by MollyTempSceneManager
    //set up state manager
   public CustomerBaseState currentCustomerState;
   public  WaitingInLineState waitingInLineState = new WaitingInLineState();
   public  OrderingState orderingState = new OrderingState();
   public CustomerExitState customerExitState = new CustomerExitState();

    //Playing a few property types here to grab these locations when the customer prefab is first instatiated
    public Transform alienCustomerPrefab;
    public GameObject orderingLocation;
    public GameObject customerExitLocation;

    public Vector3 orderingPosVector;


    public float customerSpeed = 5f;


    void Start()
    {
        //HI MONDAE:Trying to initialize customer and orderlocation variables here to reference in state scripts
        orderingPosVector = orderingLocation.transform.position;
        customerExitLocation = GameObject.FindGameObjectWithTag("Exit Location");

       
        //starting state for the customer before ordering
        currentCustomerState = waitingInLineState;

        currentCustomerState.EnterState(this);
    }

    void Update()
    {
        currentCustomerState.UpdateState(this);
    }

    public void SwitchState (CustomerBaseState state)
    {
        currentCustomerState = state;
        state.EnterState(this);
    }

    
}
