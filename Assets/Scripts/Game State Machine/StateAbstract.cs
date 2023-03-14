using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public abstract class StateAbstract
{
    public abstract void EnterState(StateManager manager);
    public abstract void UpdateState(StateManager manager);
    public abstract void ExitState(StateManager manager);

}
