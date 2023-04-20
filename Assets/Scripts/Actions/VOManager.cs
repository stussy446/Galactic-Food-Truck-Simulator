using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class VOManager : MonoBehaviour
{

    // Set the main audio source for the scene
    [SerializeField] private AudioSource source;
    private string dataPath = "Voice Overs/";

    /// <summary>
    /// Adds the PLayAudioClip as a listeners to all the possible player actions
    /// </summary>
    private void OnEnable()
    {
        ActionList.OnButtonPressed += PlayAudioClip;
        ActionList.OnEnteredButtonPressing += PlayAudioClip;
        ActionList.OnPlayerCloseToLosing += PlayAudioClip;
        ActionList.OnEnteredFoodReplicator += PlayAudioClip;
        ActionList.OnDoneReplicatingFood += PlayAudioClip;
        ActionList.OnCustomerReceivedFood += PlayAudioClip;
        ActionList.OnTriedInteractingWithInactiveButton += PlayAudioClip;
        ActionList.OnEnteredTranslator += PlayAudioClip;
        ActionList.OnExitedTranslator += PlayAudioClip;
        ActionList.OnCustomerArrived += PlayAudioClip;
        ActionList.OnCustomerOrdered += PlayAudioClip;
        ActionList.OnCustomerLeft += PlayAudioClip;

    }

    /// <summary>
    /// Plays a random audio clip from correct list
    /// </summary>
    /// <param name="type"></param>
    public void PlayAudioClip(ActionType type)
    {
        
        if (SqliteScript.GetSize("LineID", type.ToString()) > 0)
        {
            int index = UnityEngine.Random.Range(1, SqliteScript.GetSize("LineID", type.ToString()));
            string filePath = dataPath + SqliteScript.GetLine("FileName", type.ToString(), "LineID", index);
            AudioClip audioClip = Resources.Load<AudioClip>(filePath);
            
            if (!source.isPlaying)
            {
                StartCoroutine(PlayClip(audioClip));
            }
        }
        else
        {
            Debug.LogError("There are no audio clips to play");
        }
    }

    private IEnumerator PlayClip(AudioClip audio)
    {
        source.clip = audio;
        source.Play();
        yield return new WaitUntil(() => !source.isPlaying);
        Resources.UnloadAsset(audio);
    }

    /// <summary>
    /// Removes the listeners from the actions
    /// </summary>
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
