using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class responsible for initializing and switching between all concrete states.
/// </summary>
public class StateManager : MonoBehaviour
{
    public Image interactFeedback;

    public static StateManager instance;

    public InputManager playerInputManager;

    // Cache whatever state user is currently in
    public StateAbstract currentState;

    // Initialize every concrete state
    public ReceivingOrderState receivingOrderState = new ReceivingOrderState();
    public FreeRoamingState freeRoamingState = new FreeRoamingState();
    public TranslationState translationState = new TranslationState();
    public FulfillingOrderState fulfillingOrderState = new FulfillingOrderState();
    public PressingButtonState pressingButtonState = new PressingButtonState();

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        // Sets currentState to the first state of the whole game
        currentState = freeRoamingState;

        // Enter first state
        currentState.EnterState(this);
    }

    void Update()
    {
        // Runs the Update Function on each specific state
        currentState.UpdateState(this);
    }

    public void SwitchStates(StateAbstract newState)
    {
        // Set currentState to a new State
        currentState = newState;

        // Runs the "Start" function of that state
        currentState.EnterState(this);
    }
}
