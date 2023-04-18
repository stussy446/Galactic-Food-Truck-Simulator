using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TutorialAbstract
{
    public abstract void EnterState(TutorialStateManager manager);
    public abstract void UpdateState(TutorialStateManager manager);
    public abstract void ExitState(TutorialStateManager manager);
}
