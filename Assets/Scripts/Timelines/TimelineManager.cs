using UnityEngine;
using UnityEngine.Playables;

public class TimelineManager : MonoBehaviour
{
    [SerializeField] PlayableDirector director;
    [SerializeField] GameObject menuCanvas;

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

    public void SwitchToMainMenu()
    {
        menuCanvas.SetActive(true);
    }
}
