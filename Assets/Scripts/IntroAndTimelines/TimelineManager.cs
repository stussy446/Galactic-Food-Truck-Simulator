using UnityEngine;
using UnityEngine.Playables;

public class TimelineManager : MonoBehaviour
{
    [SerializeField] GameObject menuCanvas;
    [SerializeField] AudioSource audioSource;

    PlayableDirector director;

    private void Awake()
    {
        director = GetComponent<PlayableDirector>();
        if (director == null) 
        {
            Debug.Log("no director available");
        }
    }

    public void PlayMusic()
    {
        audioSource.Play();
    }

    public void StopMusic()
    {
        audioSource.Stop();
    }

    public void SwitchToMainMenu()
    {
        menuCanvas.SetActive(true);
    }
}
