using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StressController : MonoBehaviour
{
    [SerializeField] private Slider slider;

    private float stressLevel; 

    // Update is called once per frame
    void Update()
    {
        PestMover[] pestMovers = FindObjectsOfType<PestMover>();
        if (pestMovers.Length == 0)
        {
            stressLevel -= 0.025f * Time.deltaTime;
            slider.value = stressLevel;
            return;
        }
        stressLevel += pestMovers.Length * 0.01f * Time.deltaTime;
        slider.value = stressLevel;
    }
}
