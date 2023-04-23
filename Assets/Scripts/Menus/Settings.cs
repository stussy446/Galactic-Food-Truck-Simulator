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

    /// <summary>
    /// Adjusts the volume of the background music based on the current value of the volume slider
    /// </summary>
    public void AdjustVolume()
    {
        if(backgroundAudio != null)
        {
            backgroundAudio.volume = volumeSlider.value;
        }
    }
    
}
