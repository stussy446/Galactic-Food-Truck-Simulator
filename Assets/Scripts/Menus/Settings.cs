using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] AudioSource backgroundAudio;
    [SerializeField] Slider volumeSlider;

    private void Awake()
    {
        volumeSlider.value = backgroundAudio.volume;

        if(backgroundAudio == null)
        {
            Debug.LogError("Missing background Audio, please add appropriate audiosource to Settings script in the Settings Panel game object");
        }
    }
    public void AdjustVolume()
    {
        backgroundAudio.volume = volumeSlider.value;
    }
    
}
