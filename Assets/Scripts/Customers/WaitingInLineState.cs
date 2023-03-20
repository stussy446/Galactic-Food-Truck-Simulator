using UnityEngine;
using TMPro;

public class WaitingInLineState : CustomerBaseState
{

    /// <summary>
    /// Creates timer and initiates countdown for state switch to OrderingState
    /// </summary>

    private float currentTime = 0f;
    private float startingTime = 5f;


    public override void EnterState(CustomerStateManager customerState)
    {
        Debug.Log("I am waiting in line!!!");
    }


    public override void UpdateState(CustomerStateManager customerState)
    {
        currentTime = startingTime -= 1 * Time.deltaTime;
        if(currentTime <= 0)
        {
            customerState.SwitchState(customerState.orderingState);
        }
    }

}
