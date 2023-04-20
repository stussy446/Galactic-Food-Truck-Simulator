using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

/// <summary>
/// Class responsible for initializing and switching between all concrete states.
/// </summary>
public class StateManager : MonoBehaviour
{
    // Interact UI Element
    public GameObject interactFeedback;

    // Singleton
    public static StateManager instance;

    // Reference to the player inputManager
    public InputManager playerInputManager;

    // Cache whatever state user is currently in
    public StateAbstract currentState;

    // Lose condition texts
    public GameObject lostMenu;
    public TMP_Text textToShow;
    public TMP_Text loseToExplosionText;
    public TMP_Text loseToStressText;

    //High score objects reference
    [SerializeField] private HighScoreManager highScoreManager;

    // Initialize every concrete state
    public ReceivingOrderState receivingOrderState = new ReceivingOrderState();
    public FreeRoamingState freeRoamingState = new FreeRoamingState();
    public TranslationState translationState = new TranslationState();
    public FulfillingOrderState fulfillingOrderState = new FulfillingOrderState();
    public PressingButtonState pressingButtonState = new PressingButtonState();
    public LostGameState lostGameState = new LostGameState();

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
        if (GameManager.instance.gamePaused == true)
            return;

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

    public void ToggleLostMenu(bool toggle, TMP_Text textToShow)
    {
        lostMenu.SetActive(toggle);
        textToShow.gameObject.SetActive(toggle);
    }

    public void EnableHighScoreMenu()
    {
        ToggleLostMenu(false, textToShow);
        highScoreManager.EnableScoreboard();
    }

}
