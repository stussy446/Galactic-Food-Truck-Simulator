using System;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] AudioSource backgroundAudio;
    [SerializeField] Slider volumeSlider;
    [SerializeField] Slider xSensitivitySlider;
    [SerializeField] Slider ySensitivitySlider;
    CameraMover cameraMover;


    private void Awake()
    {
        if(backgroundAudio != null)
        {
            volumeSlider.value = backgroundAudio.volume;
        }

    }

    private void Start()
    {
       cameraMover = FindObjectOfType<CameraMover>();
       if(cameraMover == null)
        {
            xSensitivitySlider.gameObject.SetActive(false);
            ySensitivitySlider.gameObject.SetActive(false);

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
            // TODO: save to player prefs

        }
    }

    public void AdjustHorizontalSensitivity()
    {
        cameraMover.SensitivityX = xSensitivitySlider.value;

        // TODO: save to player prefs
    }

    public void AdjustVerticalSensitivity()
    {
        cameraMover.SensitivityY = ySensitivitySlider.value;

        // TODO: save to player prefs
    }

}
