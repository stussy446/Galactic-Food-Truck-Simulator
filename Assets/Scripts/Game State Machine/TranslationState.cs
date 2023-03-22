using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Game State for whenever user is exclusively interacting with the translator.
/// </summary>
public class TranslationState : StateAbstract
{
    private TranslatorFunction translator;

    public override void EnterState(StateManager manager)
    {
        Debug.Log("Translation State");
        translator = MonoBehaviour.FindObjectOfType<TranslatorFunction>();
        translator.gameObject.GetComponent<Collider>().enabled = false;
        // TODO: Bring Translator to the screen (think Among Us task)
    }

    public override void ExitState(StateManager manager)
    {
        translator.gameObject.GetComponent<Collider>().enabled = true;

        // Goes back to free roaming state
        manager.SwitchStates(manager.freeRoamingState);
    }

    public override void UpdateState(StateManager manager)
    {
        // TODO: Execute translator mechanics here or build another State Machine
        // TODO: Exit whenever user clicks outside of the translator
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ExitState(manager);
        }
    }
}
