using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] AudioSource backgroundAudio;
    [SerializeField] Slider volumeSlider;

    private void Awake()
    {
        if(backgroundAudio != null)
        {
            volumeSlider.value = backgroundAudio.volume;
        }
    }

    public void AdjustVolume()
    {
        if(backgroundAudio != null)
        {
            backgroundAudio.volume = volumeSlider.value;
        }
    }
    
}
