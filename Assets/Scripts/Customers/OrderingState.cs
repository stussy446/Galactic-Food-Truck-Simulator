using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderingState : MonoBehaviour
{
    VoiceOverManager voiceOverManager;

    [SerializeField]
    private GameObject customerSpawnLocation;


   /// <summary>
   /// Populates customer with character model, orderID, and VO
   /// </summary>
    void Start()
    {
        CustomerEnterAnimation();
        //need time for the customer to arrive before voice
        CustomerVoiceClip();
    }

    private void CustomerEnterAnimation()
    {
        //TODO: Connect visual of customer arrival
        // Spawn customer and move them to window
    }
    private void CustomerVoiceClip()
    {
        //TODO:Trigger voice clip for entrance
        voiceOverManager.PlayAudioClip(ActionType.CustomerArrived);
    }

 

    /// <summary>
    /// Check to see if order is correctly fufilled from FufillingOrderState. If yes, move to ExitState. If no, send player back to FufillingOrderState.
    /// </summary>
  
    void Update()
    {
        
    }
}
