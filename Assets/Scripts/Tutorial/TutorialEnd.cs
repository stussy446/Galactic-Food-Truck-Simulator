using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialEnd : TutorialAbstract
{
    public override void EnterState(TutorialStateManager manager)
    {
        // Final VO
    }

    public override void ExitState(TutorialStateManager manager)
    {
        
    }

    public override void UpdateState(TutorialStateManager manager)
    {
        if (!manager.source.isPlaying) 
        {
            SceneManager.LoadScene(2);
        }
    }
}
