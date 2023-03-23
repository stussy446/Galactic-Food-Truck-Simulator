using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Customer Config", menuName = "Configs/Customer Config", order = 0)]
public class CustomerScriptableObject : ScriptableObject
{
    public int orderId;
    public Mesh mesh;
    public Material material;
    public AudioClip orderAudio;
    public AudioClip thankyouAudio;
    public int language;


    public void PlayOrderAudio(AudioSource audioSource)
    {
        audioSource.PlayOneShot(orderAudio);
    }

    public void PlayThankYouAudio(AudioSource audioSource)
    {
        audioSource.PlayOneShot(thankyouAudio);
    }
}
