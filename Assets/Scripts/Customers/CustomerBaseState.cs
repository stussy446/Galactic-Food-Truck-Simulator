using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CustomerBaseState
{
    public abstract void UpdateState(CustomerStateManager customerState);
    public abstract void EnterState(CustomerStateManager customerState);

}
