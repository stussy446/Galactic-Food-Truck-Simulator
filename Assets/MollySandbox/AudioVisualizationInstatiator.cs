using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioVisualizationInstatiator : MonoBehaviour
{

    [SerializeField]
    public GameObject prefabShape;
    GameObject instantiatedShape;
    private float randomAudioSample;
    GameObject[] prefabShapeArray = new GameObject[64];
    public float maxScale;

    // Start is called before the first frame update
    void Start()
    {
        //instantiatedShape = Instantiate(prefabShape);
        //instantiatedShape.transform.position = this.transform.position;
        //prefabShape.transform.parent = this.transform;

        for (int i = 0; i < 8; i++)
        {
            GameObject instancePrefabShape = (GameObject)Instantiate(prefabShape);
            instancePrefabShape.transform.position = this.transform.position;
            instancePrefabShape.transform.parent = this.transform;
            instancePrefabShape.name = "PrefabShape" + i;
            this.transform.localPosition = new Vector3(0, 0, (float).5 * i);
            instancePrefabShape.transform.position = Vector3.forward * 10;
            prefabShapeArray[i] = instancePrefabShape;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //randomAudioSample = AudioData.audioSamples[Random.Range(0, 8)] * maxScale;
        //if (AudioData.bossAIAudioSource.isPlaying)
        //{
        //    instantiatedShape.transform.localScale = new Vector3(5,5, randomAudioSample);
        //}
        //else
        //{
        //    instantiatedShape.transform.localScale = new Vector3(5, 5, 0);
        //}
        if (AudioData.bossAIAudioSource.isPlaying)
        {
            for (int i = 0; i < 8; i++)
            {
                if (prefabShapeArray[i] != null)
                {
                    prefabShapeArray[i].transform.localScale = new Vector3(1, AudioData.audioSamples[i] * maxScale, 1);
                }
            }
        }
    }
}
