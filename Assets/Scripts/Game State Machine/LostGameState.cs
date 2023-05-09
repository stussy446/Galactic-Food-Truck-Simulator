using System.Collections;
using UnityEngine;

public class LostGameState : StateAbstract
{
    public override void EnterState(StateManager manager)
    {
        GameManager.instance.gamePaused = true;
        manager.playerInputManager.DisableMovement(true);
        StateManager.instance.StartCoroutine(WaitforDeathMessage());
    }

    public override void ExitState(StateManager manager) { }

    public override void UpdateState(StateManager manager) { }

    /// <summary>
    /// Shoes the Lost Game Menu for a set amount of time and then shows the high score
    /// </summary>
    /// <returns>enumerator</returns>
    public IEnumerator WaitforDeathMessage()
    {
        StateManager.instance.ToggleLostMenu(true, StateManager.instance.textToShow);
        yield return new WaitForSeconds(5);
        StateManager.instance.EnableHighScoreMenu();
    }

}
