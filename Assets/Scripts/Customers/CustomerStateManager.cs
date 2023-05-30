using UnityEngine;

public class CustomerStateManager : MonoBehaviour
{ 
    /// <summary>
    /// Manages state changes for customer
    /// </summary>
    public static CustomerStateManager instance;
    [HideInInspector] public Customer customer;

    [Header("Customer States")]
    private CustomerBaseState currentCustomerState;
    private  WaitingInLineState waitingInLineState;
    private  OrderingState orderingState;
    private CustomerExitState customerExitState;

    [Header("Location GameObjects")]
    [SerializeField]
    private GameObject customerResetLocation;
    [SerializeField]
    private GameObject orderingLocation;
    [SerializeField]
    private GameObject customerExitLocation;

    public GameObject OrderingLocation { get { return orderingLocation; } }
    public CustomerExitState CustomerExitState { get { return customerExitState; } }

    public GameObject CustomerExitLocation { get { return customerExitLocation; } }
    public GameObject CustomerResetLocation { get { return customerResetLocation; } }

    public WaitingInLineState WaitingInLineState { get { return waitingInLineState; } }

    public OrderingState OrderingState { get { return orderingState; } }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }

        waitingInLineState = new WaitingInLineState();
        orderingState = new OrderingState();
        customerExitState = new CustomerExitState();

    }


    private void Start()
    {
        
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

    public void DestroyStates()
    {
        waitingInLineState = null;
        orderingState.Disable();
        orderingState = null;
        customerExitState = null;
        currentCustomerState = null;
    }
}
