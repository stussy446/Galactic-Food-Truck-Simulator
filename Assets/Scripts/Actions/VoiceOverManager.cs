using System;
using System.Collections.Generic;
using UnityEngine;

public class VoiceOverManager : MonoBehaviour
{
    // Set the main audio source for the scene
    [SerializeField] private AudioSource source;

    // Creates a list of voice over clips for each action
    [SerializeField] private List<AudioClip> buttonPressed;
    [SerializeField] private List<AudioClip> playerCloseToLosing;
    [SerializeField] private List<AudioClip> enteredFoodReplicator;
    [SerializeField] private List<AudioClip> doneReplicatingFood;
    [SerializeField] private List<AudioClip> customerReceivedFood;
    [SerializeField] private List<AudioClip> triedInteractingWithInactiveButton;
    [SerializeField] private List<AudioClip> enteredTranslator;
    [SerializeField] private List<AudioClip> exitedTranslator;
    [SerializeField] private List<AudioClip> customerArrived;
    [SerializeField] private List<AudioClip> customerOrdered;
    [SerializeField] private List<AudioClip> customerLeft;
    
    // A list of all the possible actions
    private List<Action<ActionType>> allActions;

    /// <summary>
    /// Gets the list needed depending on what action was taken.
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    private List<AudioClip> GetClipList(ActionType type)
    {
        switch (type)
        {
            case ActionType.ButtonPressed: return buttonPressed;
            case ActionType.PlayerCloseToLosing: return playerCloseToLosing;
            case ActionType.EnteredFoodReplicator: return enteredFoodReplicator;
            case ActionType.DoneReplicatingFood: return doneReplicatingFood;
            case ActionType.CustomerReceivedFood: return customerReceivedFood;
            case ActionType.TriedInteractingWithInactiveButton: return triedInteractingWithInactiveButton;
            case ActionType.EnteredTranslator: return enteredTranslator;
            case ActionType.ExitedTranslator: return exitedTranslator;
            case ActionType.CustomerArrived: return customerArrived;
            case ActionType.CustomerOrdered: return customerOrdered;
            case ActionType.CustomerLeft: return customerLeft;
            default: return null;
        }
    }

    /// <summary>
    /// Plays a random audio clip from correct list
    /// </summary>
    /// <param name="type"></param>
    public void PlayAudioClip(ActionType type)
    {
        Debug.Log("We get here");
        List<AudioClip> audioClips = GetClipList(type);
        if (audioClips.Count > 0)
        {
            int index = UnityEngine.Random.Range(0, audioClips.Count);
            AudioClip audioClip = audioClips[index];
            source.clip = audioClip;
            if (!source.isPlaying)
            {
                source.Play();
            }
        }
    }

    private void Start()
    {
        ActionList.OnButtonPressed += PlayAudioClip;
        ActionList.OnEnteredButtonPressing += PlayAudioClip;
        ActionList.OnPlayerCloseToLosing+= PlayAudioClip;
        ActionList.OnEnteredFoodReplicator+= PlayAudioClip;
        ActionList.OnDoneReplicatingFood+= PlayAudioClip;
        ActionList.OnCustomerReceivedFood+= PlayAudioClip;
        ActionList.OnTriedInteractingWithInactiveButton+= PlayAudioClip;
        ActionList.OnEnteredTranslator+= PlayAudioClip;
        ActionList.OnExitedTranslator+= PlayAudioClip;
        ActionList.OnCustomerArrived+= PlayAudioClip;
        ActionList.OnCustomerOrdered+= PlayAudioClip;
        ActionList.OnCustomerLeft+= PlayAudioClip;
        
    }

    private void OnDisable()
    {
        ActionList.OnButtonPressed -= PlayAudioClip;
        ActionList.OnEnteredButtonPressing -= PlayAudioClip;
        ActionList.OnPlayerCloseToLosing -= PlayAudioClip;
        ActionList.OnEnteredFoodReplicator -= PlayAudioClip;
        ActionList.OnDoneReplicatingFood -= PlayAudioClip;
        ActionList.OnCustomerReceivedFood -= PlayAudioClip;
        ActionList.OnTriedInteractingWithInactiveButton -= PlayAudioClip;
        ActionList.OnEnteredTranslator -= PlayAudioClip;
        ActionList.OnExitedTranslator -= PlayAudioClip;
        ActionList.OnCustomerArrived -= PlayAudioClip;
        ActionList.OnCustomerOrdered -= PlayAudioClip;
        ActionList.OnCustomerLeft -= PlayAudioClip;
    }
}
