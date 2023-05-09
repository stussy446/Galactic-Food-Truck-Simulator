using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAudioVisualization : MonoBehaviour
{
    public int frequencyBand;
    public Light discoLight;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        discoLight.intensity = AudioData.frequencyBandBuffer[frequencyBand] * 10;
    }
}
