using UnityEngine;


/// <summary>
/// Manages customer order flow
/// 1. Closes Button Box while customer is waiting for correct order
/// 2. Moves customer toward service window (orderPos)
/// 3. Connects customer order ID to translator
/// 4. Plays order audio
/// 5. Reopens Button Box
/// </summary>
public class OrderingState : CustomerBaseState
{
    private GameObject alienCustomer;
    private Vector3 customerPos, orderPos;
    private float customerSpeed;
    private CustomerScriptableObject customerOrderVO;
    private AudioSource audioSource;

    private CustomerStateManager cusState;
    private BoxOpener boxOpener;
    private CustomerLight customerLight;

    public override void EnterState(CustomerStateManager customerState)
    {

        // Adding listeners for when the customer has ordered and when correct order is fufilled

        ActionList.OnDoneReplicatingFood += ToCustomerExitState;
        ActionList.OnCustomerOrdered += OnCustomerInteract;
        boxOpener = MonoBehaviour.FindObjectOfType<BoxOpener>();
        customerLight = MonoBehaviour.FindObjectOfType<CustomerLight>(includeInactive:true);

        alienCustomer = customerState.customer.CustomerPrefab;
        customerPos = alienCustomer.transform.position;
        orderPos = customerState.orderingLocation.transform.position;
        customerSpeed = customerState.customer.CustomerSpeed;
        customerOrderVO = customerState.customer.GetCurrentCustomer();
        audioSource = customerState.customer.CustomerAudioSource;

        alienCustomer.transform.position = customerPos;
        boxOpener.CloseBox();
        customerLight.gameObject.SetActive(true);

        ActionList.OnCustomerArrived?.Invoke(ActionType.CustomerArrived);

        cusState = customerState;

    }

    /// <summary>
    /// Moves customer toward service window
    /// </summary>
    /// <param name="customerState"></param>

    public override void UpdateState(CustomerStateManager customerState)
    {
        alienCustomer.transform.position = Vector3.MoveTowards(alienCustomer.transform.position, orderPos, customerSpeed * Time.deltaTime);
    }

    /// <summary>
    /// Connect customer order ID to translator and plays order audio
    /// </summary>
    /// <param name="actionType"></param>
    public void OnCustomerInteract(ActionType actionType)
    {
        TranslateActions.OnReceiveOrder(customerOrderVO.language, customerOrderVO.orderId);
        customerOrderVO.PlayOrderAudio(audioSource);
        cusState.customer.VOCoroutine();
    }

    private void ToCustomerExitState(ActionType actionType)
    {
        ExitState(CustomerStateManager.instance);
    }
  
    /// <summary>
    /// Removes listeners and reopens button box
    /// </summary>
    /// <param name="customerState"></param>

    public override void ExitState(CustomerStateManager customerState)
    {
        ActionList.OnDoneReplicatingFood -= ToCustomerExitState;
        ActionList.OnCustomerOrdered -= OnCustomerInteract;
        customerLight.gameObject.SetActive(false);
        boxOpener.OpenBox();
        customerState.SwitchState(customerState.customerExitState);

    }
}


