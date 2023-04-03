using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))] 
public class AudioData : MonoBehaviour
{
    public static AudioSource bossAIAudioSource;

    public static float[] audioSamples = new float[64];
    public static float[] frequencySection = new float[8];



    // Start is called before the first frame update
    void Start()
    {
        bossAIAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        GetAudioSource();   
        CreateFrequencySection();
    }

    private void GetAudioSource()
    {
        bossAIAudioSource.GetSpectrumData(audioSamples, 0, FFTWindow.Blackman);
    }

    private void CreateFrequencySection()
    {
    }
}
