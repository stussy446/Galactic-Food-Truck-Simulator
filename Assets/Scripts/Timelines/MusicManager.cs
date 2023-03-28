using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class MusicManager : MonoBehaviour
{
    [SerializeField] PlayableDirector director;
    AudioSource audioSource;

    float timer = 0;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null) 
        {
            Debug.Log("no audiosource available");
        }
    }
    private void Update()
    {
        //StopIfDone();
    }

    public void PlayMusic()
    {
        audioSource.Play();
    }

    public void StopMusic()
    {
        audioSource.Stop();
    }
    private void StopIfDone()
    {
        timer += Time.deltaTime;
        if (director.duration <= timer)
        {
            StopMusic();
        }
    }
}
