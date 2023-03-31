using UnityEngine;

public class OrderingState : CustomerBaseState
{
    // VoiceOverManager voiceOverManager;
    private GameObject alienCustomer;
    private Vector3 customerPos, orderPos;
    private float customerSpeed;
    private ScriptableObject customerOrderVO;
    private AudioSource audioSource;


    public override void EnterState(CustomerStateManager customerState)
    {
        alienCustomer = customerState.alienCustomerPrefab;
        customerPos = customerState.alienCustomerPrefab.transform.position;
        orderPos = customerState.orderingLocation.transform.position;
        customerSpeed = customerState.customerSpeed;
        customerOrderVO = customerState.customerSO;
        audioSource = customerState.customerAudioSource;

        alienCustomer.transform.position = customerPos;
        customerState.buttonBox.CloseBox();

    }

    public override void UpdateState(CustomerStateManager customerState)
    {

        if (alienCustomer.transform.position != orderPos)
        {
            alienCustomer.transform.position = Vector3.MoveTowards(alienCustomer.transform.position, orderPos, customerSpeed * Time.deltaTime);
        }

        if (alienCustomer.transform.position == orderPos && audioSource.enabled && !audioSource.isPlaying)
        {
            //TODO: connect voice clip
            //voiceOverManager.PlayAudioClip(ActionType.CustomerArrived);
            TranslateActions.OnReceiveOrder(customerState.customerSO.language, customerState.customerSO.orderId); 
            //----------------FOR TESTING SCRIPTABLE OBJECT-------------------//
            customerState.customerSO.PlayOrderAudio(audioSource);
            Debug.Log("JELLY ENTITY WISHES TO PARTAKE OF THIS ESTABLISHMENT'S FINEST EXPEDIANT MEAL.");
            customerState.VOCoroutine();
        }

        if (Input.GetKeyDown(KeyCode.O) == true)
        {
            ExitState(customerState);
        }
        else
        {
            //TODO: connect wrong order voice clip
            //send player back to Replicator
        }
    }

    public override void ExitState(CustomerStateManager customerState)
    {
        customerState.buttonBox.OpenBox();
        customerState.SwitchState(customerState.customerExitState);
    }
}


