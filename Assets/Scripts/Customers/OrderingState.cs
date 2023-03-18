using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderingState : MonoBehaviour
{
    VoiceOverManager voiceOverManager;

    [SerializeField]
    private Transform customerSpawnLocation;
    [SerializeField]
    private Transform customerOrderLocation;

    [SerializeField]
    private GameObject alienCustomer;

    [SerializeField]
    private float alienSpeed = 10f;

    private Rigidbody alienRigidbody;

    [SerializeField]
    public bool correctOrderFufilled;

   /// <summary>
   /// Populates customer with character model, orderID, and VO
   /// </summary>
    void Start()
    {
        alienRigidbody = alienCustomer.GetComponent<Rigidbody>();

        CustomerEnterAnimation();
        //need time for the customer to arrive before voice
        CustomerVoiceClip();
    }

    private void CustomerEnterAnimation()
    {
        Instantiate(alienCustomer, customerSpawnLocation);
        alienCustomer.transform.position = Vector3.MoveTowards(transform.position, customerOrderLocation.position, alienSpeed * Time.deltaTime);
        //TODO: Connect visual of customer arrival
        // Spawn customer and move them to window
    }
    private void CustomerVoiceClip()
    {
        //TODO:Trigger voice clip for entrance
        //voiceOverManager.PlayAudioClip(ActionType.CustomerArrived);
        Debug.Log("BEEPBOORP please");
    }

 

    /// <summary>
    /// Check to see if order is correctly fufilled from FufillingOrderState. If yes, move to ExitState. If no, send player back to FufillingOrderState.
    /// </summary>
  
    void Update()
    {
        if (alienCustomer.transform.position != customerOrderLocation.transform.position)
        {
            alienCustomer.transform.position = Vector3.Lerp(alienCustomer.transform.position, customerOrderLocation.transform.position, alienSpeed * Time.deltaTime);
        }
        if (correctOrderFufilled)
        {
            //Change to EndState
        }
        else
        {
            // voiceOverManager.PlayAudioClip() wrong food choice
            //send player back to FufillingState
            correctOrderFufilled = false;
        }
    }

    //Destroy listeners
}
