using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] AudioSource backgroundAudio;
    [SerializeField] Slider volumeSlider;

    public void AdjustVolume()
    {
        backgroundAudio.volume = volumeSlider.value;
    }
    
}
