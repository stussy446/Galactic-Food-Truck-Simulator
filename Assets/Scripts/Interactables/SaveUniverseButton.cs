using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class SaveUniverseButton : MonoBehaviour
{
    [SerializeField] private Slider slider;

    private float maxDangerLevel = 100;
    private float dangerLevel = 100;

    private float dropSliderFactor = 0.75f;
    private float increaseSliderFactor = 8f;

    private bool buttonBeingClicked = false;

    private void OnMouseDrag()
    {
        buttonBeingClicked = true;
    }

    private void OnMouseUp()
    {
        buttonBeingClicked = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = maxDangerLevel;
        dangerLevel = maxDangerLevel;
    }

    // Update is called once per frame
    void Update()
    {
        if (!buttonBeingClicked)
        {
            dangerLevel -= dropSliderFactor * Time.deltaTime;
            SetDangerLevel(dangerLevel);
            return;
        }

        dangerLevel += increaseSliderFactor * Time.deltaTime;
        SetDangerLevel(dangerLevel);
    }

    private void SetDangerLevel(float level)
    {
        slider.value = level;
    }

}
