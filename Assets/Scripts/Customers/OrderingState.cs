using UnityEngine;

public class OrderingState : CustomerBaseState
{
    // VoiceOverManager voiceOverManager;
    private GameObject alienCustomer;
    private Vector3 customerPos, orderPos;
    private float customerSpeed;
    private CustomerScriptableObject customerOrderVO;
    private AudioSource audioSource;
    


    public override void EnterState(CustomerStateManager customerState)
    {
        ActionList.OnDoneReplicatingFood += ToCustomerExitState;

        alienCustomer = customerState.alienCustomerPrefab;
        customerPos = customerState.alienCustomerPrefab.transform.position;
        orderPos = customerState.orderingLocation.transform.position;
        customerSpeed = customerState.customerSpeed;
        customerOrderVO = customerState.customer.GetRandomCustomer();
        audioSource = customerState.customerAudioSource;

        alienCustomer.transform.position = customerPos;
        customerState.buttonBox.CloseBox();
        customerState.customerAlert.gameObject.SetActive(true);

        Debug.Log("OrderingState");

    }

    public override void UpdateState(CustomerStateManager customerState)
    {
        alienCustomer.transform.position = Vector3.MoveTowards(alienCustomer.transform.position, orderPos, customerSpeed * Time.deltaTime);

        if (alienCustomer.transform.position == orderPos && audioSource.enabled && !audioSource.isPlaying)
        {
            //TODO: connect voice clip
            //voiceOverManager.PlayAudioClip(ActionType.CustomerArrived);
            TranslateActions.OnReceiveOrder(customerOrderVO.language, customerOrderVO.orderId);
            //----------------FOR TESTING SCRIPTABLE OBJECT-------------------//
            customerOrderVO.PlayOrderAudio(audioSource);
            Debug.Log("JELLY ENTITY WISHES TO PARTAKE OF THIS ESTABLISHMENT'S FINEST EXPEDIANT MEAL.");
            customerState.VOCoroutine();
        }

        //if (Input.GetKeyDown(KeyCode.O))
        //{
        //    ExitState(customerState);
        //}
        //else
        //{
        //TODO: connect wrong order voice clip
        //send player back to Replicator
        //}

    }

    void ToCustomerExitState(ActionType actionType)
    {
        ExitState(CustomerStateManager.instance);
    }
  

    public override void ExitState(CustomerStateManager customerState)
    {
        ActionList.OnDoneReplicatingFood -= ToCustomerExitState;
        customerState.customerAlert.gameObject.SetActive(false);
        customerState.buttonBox.OpenBox();
        customerState.SwitchState(customerState.customerExitState);

    }
}


