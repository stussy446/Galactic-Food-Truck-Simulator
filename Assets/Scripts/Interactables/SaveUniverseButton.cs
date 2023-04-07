using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class SaveUniverseButton : MonoBehaviour
{
    // Reference to the slider that shows how close player is to losing
    [SerializeField] private Slider slider;

    // Set max possible danger value and current danger value
    private float maxDangerLevel = 100;
    private float dangerLevel = 100;

    // Set how fast slilder lowers and how fast it increases
    private float dropSliderFactor = 1.25f;
    private float increaseSliderFactor = 8f;

    // Checks to see if button is being pressed
    private bool buttonBeingClicked = false;

    // Button Positions
    private Vector3 notPressed;
    private Vector3 pressed;

    private void OnMouseDown()
    {
        ActionList.OnButtonPressed?.Invoke(ActionType.ButtonPressed);
    }

    private void OnMouseDrag()
    {
        buttonBeingClicked = true;
    }

    private void OnMouseUp()
    {
        buttonBeingClicked = false;
    }

    void Start()
    {
        // Sets max value of the slider
        slider.maxValue = maxDangerLevel;

        // Sets current danger level to max
        dangerLevel = maxDangerLevel;
    }

    void Update()
    {
        // if the button is not being clicked, decrease slider value
        if (!buttonBeingClicked)
        {
            dangerLevel -= dropSliderFactor * Time.deltaTime;
            SetDangerLevel(dangerLevel);
            if (dangerLevel < 20 && dangerLevel > 19.8f)
            {
                ActionList.OnPlayerCloseToLosing?.Invoke(ActionType.PlayerCloseToLosing);
            }
            if (dangerLevel <= 0)
            {
                StateManager.instance.textToShow = StateManager.instance.loseToExplosionText;
                StateManager.instance.SwitchStates(StateManager.instance.lostGameState);
            }
            return;
        }

        // if the button is being pressed, increase slider value if it hasn't reached max value
        if (dangerLevel < maxDangerLevel)
        {
            dangerLevel += increaseSliderFactor * Time.deltaTime;
            SetDangerLevel(dangerLevel);
        }      
    }

    /// <summary>
    /// Sets the slider value.
    /// </summary>
    /// <param name="level">What value to set the slider to.</param>
    private void SetDangerLevel(float level)
    {
        slider.value = level;
    }

}
