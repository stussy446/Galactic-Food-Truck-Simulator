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

    [SerializeField]
    public GameObject alienCustomerPrefab,customerResetLocation,orderingLocation, customerExitLocation;
    [SerializeField]
    public bool correctOrderFufilled;
    [SerializeField]
    public float customerSpeed = 5f;


    void Start()
    {
        correctOrderFufilled = false;
       
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

    public void OnCustomerEnter()
    {
        //TODO: set prefab model
        //set VO clips
        //set order
        alienCustomerPrefab.SetActive(true);
    }

    public void OnCharacterExit()
    {
        alienCustomerPrefab.SetActive(false);
    }

    
}
