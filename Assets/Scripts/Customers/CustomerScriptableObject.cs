using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Customer Config", menuName = "Configs/Customer Config", order = 0)]
public class CustomerScriptableObject : ScriptableObject
{
    public int orderId;
    public GameObject modelPrefab;
    public AudioClip orderAudio;
    public AudioClip thankyouAudio;
    public int language;


    public void PlayOrderAudio(AudioSource audioSource)
    {
        if(orderAudio == null)
        {
            Debug.LogError($"the provided orderAudio clip is null for customer with id {orderId}, please make sure the audioclip is correctly assigned to the customer");
            return;
        }

        audioSource.PlayOneShot(orderAudio);

    }

    public void PlayThankYouAudio(AudioSource audioSource)
    {
        audioSource.PlayOneShot(thankyouAudio);
    }
}
