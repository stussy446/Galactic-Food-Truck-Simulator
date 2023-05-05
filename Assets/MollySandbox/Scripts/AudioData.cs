using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))] 
public class AudioData : MonoBehaviour
{
    public static AudioSource bossAIAudioSource;

    public static float[] audioSamples = new float[512];
    public static float[] frequencySection = new float[8];

    public static float[] frequencyBandBuffer = new float[8];

    private float[] buffer = new float[8];

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
        BufferFrequencyBand();
    }

    private void GetAudioSource()
    {
        bossAIAudioSource.GetSpectrumData(audioSamples, 0, FFTWindow.Blackman);
    }

    private void CreateFrequencySection()
    {
        int index = 0;
        for(int i = 0; i < 8; i++)
        {
            float average = 0;
            int sampleCount = (int)Mathf.Pow(2, i) * 2;
            if(i == 7)
            {
                sampleCount += 2;
                
            }

            for (int j = 0; j < sampleCount; j++)
            {
                average += audioSamples[index] * (index + 1);
                index++;
            }
            average /= index;

            frequencySection[i] = average * 10;
        }
    }

    private void BufferFrequencyBand()
    {
        for(int i = 0; i < 8; i++)
        {
            if (frequencySection[i] > frequencyBandBuffer[i])
            {
                frequencyBandBuffer[i] = frequencySection[i];
                buffer[i] = 0.005f;
            }
            if (frequencySection[i] < frequencyBandBuffer[i])
            {
                frequencyBandBuffer[i] -= buffer[i];
                buffer[i] *= 1.2f;
            }
        }
    }
}
