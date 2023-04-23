using UnityEngine;

public class CustomerStateManager : MonoBehaviour
{ 
    public static CustomerStateManager instance;
    [HideInInspector] public Customer customer;

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

    private void Start()
    {
        if(instance == null)
        {
            instance = this;
        }

        customer = GetComponent<Customer>();
        currentCustomerState = waitingInLineState;
        currentCustomerState.EnterState(this);
    }

    private void Update()
    {
        if (GameManager.instance.gamePaused == true)
            return;

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
