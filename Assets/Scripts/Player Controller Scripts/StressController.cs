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
        if (GameManager.instance.gamePaused == true)
            return;

        PestMover[] pestMovers = FindObjectsOfType<PestMover>();
        if (pestMovers.Length == 0 && stressLevel > 0)
        {
            stressLevel -= 0.025f * Time.deltaTime;
            slider.value = stressLevel;
            return;
        }
        stressLevel += pestMovers.Length * 0.035f * Time.deltaTime;
        slider.value = stressLevel;

        if (slider.value >= 5)
        {
            StateManager.instance.textToShow = StateManager.instance.loseToStressText;
            StateManager.instance.SwitchStates(StateManager.instance.lostGameState);
        }
    }
}
