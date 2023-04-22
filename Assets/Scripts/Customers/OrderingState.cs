using UnityEngine;

public class OrderingState : CustomerBaseState
{
    // VoiceOverManager voiceOverManager;
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

        Debug.Log("OrderingState");

        cusState = customerState;

    }

    public override void UpdateState(CustomerStateManager customerState)
    {
        alienCustomer.transform.position = Vector3.MoveTowards(alienCustomer.transform.position, orderPos, customerSpeed * Time.deltaTime);
    }

    public void OnCustomerInteract(ActionType actionType)
    {
        TranslateActions.OnReceiveOrder(customerOrderVO.language, customerOrderVO.orderId);
        customerOrderVO.PlayOrderAudio(audioSource);
        Debug.Log("JELLY ENTITY WISHES TO PARTAKE OF THIS ESTABLISHMENT'S FINEST EXPEDIANT MEAL.");
        cusState.customer.VOCoroutine();
    }

    void ToCustomerExitState(ActionType actionType)
    {
        ExitState(CustomerStateManager.instance);
    }
  

    public override void ExitState(CustomerStateManager customerState)
    {
        ActionList.OnDoneReplicatingFood -= ToCustomerExitState;
        ActionList.OnCustomerOrdered -= OnCustomerInteract;
        customerLight.gameObject.SetActive(false);
        boxOpener.OpenBox();
        customerState.SwitchState(customerState.customerExitState);

    }
}


