using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class CustomerStateManager : MonoBehaviour
{
   /// <summary>
   /// Controls Customer State Machine
   /// </summary> 
   /// 

    public static CustomerStateManager instance;

    public Customer customer;

    [Header("Customer States")]
    public CustomerBaseState currentCustomerState;
    public  WaitingInLineState waitingInLineState = new WaitingInLineState();
    public  OrderingState orderingState = new OrderingState();
    public CustomerExitState customerExitState = new CustomerExitState();

    [Header("Location GameObjects")]
    [SerializeField]
    public GameObject customerResetLocation;
    [SerializeField]
    public GameObject orderingLocation;
    [SerializeField]
    public GameObject customerExitLocation;

    [Header("Customer Dependencies")]
    public BoxOpener buttonBox;
    public Light customerAlert;

    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }

        customer = GetComponent<Customer>();
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
   
   void ToCustomerOrder(ActionType actionType)
    {
        SwitchState(orderingState);
    }


}
