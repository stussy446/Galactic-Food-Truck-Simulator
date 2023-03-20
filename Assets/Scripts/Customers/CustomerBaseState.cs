using UnityEngine;

public abstract class CustomerBaseState
{

    
   public abstract void EnterState(CustomerStateManager customerState);

   public abstract void UpdateState(CustomerStateManager customerState);


}
