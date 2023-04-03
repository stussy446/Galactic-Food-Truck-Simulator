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
        // Find the translator in the scene
        translator = MonoBehaviour.FindObjectOfType<TranslatorFunction>();

        // Set the translator dial to interactable by disabling the translator's collider
        translator.gameObject.GetComponent<Collider>().enabled = false;

        // Set player position to be right in front of the translator
        manager.playerInputManager.GoToTranslatorPosition();

    }

    public override void ExitState(StateManager manager)
    {
        // Set dial to not interactable
        translator.gameObject.GetComponent<Collider>().enabled = true;

        // Goes back to free roaming state
        manager.SwitchStates(manager.freeRoamingState);
    }

    public override void UpdateState(StateManager manager)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ExitState(manager);
        }
    }
}
