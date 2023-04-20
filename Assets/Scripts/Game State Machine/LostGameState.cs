using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class LostGameState : StateAbstract
{
    public override void EnterState(StateManager manager)
    {
        GameManager.instance.gamePaused = true;
        manager.playerInputManager.DisableMovement(true);
        StateManager.instance.StartCoroutine(WaitforDeathMessage());
        //        StateManager.instance.ToggleLostMenu(true, StateManager.instance.textToShow);
    }

    public override void ExitState(StateManager manager)
    {
        
    }

    public override void UpdateState(StateManager manager)
    {
        
    }

    public IEnumerator WaitforDeathMessage()
    {
        StateManager.instance.ToggleLostMenu(true, StateManager.instance.textToShow);
        yield return new WaitForSeconds(5);
        StateManager.instance.EnableHighScoreMenu();
    }

}
