using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslationState : StateAbstract
{
    public override void EnterState(StateManager manager)
    {
        // TODO: Bring Translator to the screen (think Among Us task)
    }

    public override void ExitState(StateManager manager)
    {
        // Goes back to free roaming state
        manager.SwitchStates(manager.freeRoamingState);
    }

    public override void UpdateState(StateManager manager)
    {
        // TODO: Execute translator mechanics here or build another State Machine
        // TODO: Exit whenever user clicks outside of the translator
    }
}
