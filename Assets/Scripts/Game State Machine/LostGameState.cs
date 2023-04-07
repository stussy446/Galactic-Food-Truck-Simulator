using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class LostGameState : StateAbstract
{
    public override void EnterState(StateManager manager)
    {
        manager.playerInputManager.DisableMovement();
        StateManager.instance.ToggleLostMenu(true, StateManager.instance.textToShow);
    }

    public override void ExitState(StateManager manager)
    {
        
    }

    public override void UpdateState(StateManager manager)
    {
        
    }

}
