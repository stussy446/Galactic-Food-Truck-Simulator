using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public StateAbstract currentState;

    public ReceivingOrderState receivingOrderState = new ReceivingOrderState();
    public FreeRoamingState freeRoamingState = new FreeRoamingState();
    public TranslationState translationState = new TranslationState();
    public FulfillingOrderState fulfillingOrderState = new FulfillingOrderState();
    public PressingButtonState pressingButtonState = new PressingButtonState();

    // Start is called before the first frame update
    void Start()
    {
        currentState = freeRoamingState;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchStates(StateAbstract newState)
    {
        currentState = newState;
        currentState.EnterState(this);
    }
}
