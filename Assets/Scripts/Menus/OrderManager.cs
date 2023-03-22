using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    // TODO: I feel like this should be a separate Customer script that hold information about the customer (and thats where we would plug in the scriptable object)
    CustomerStateManager customer;

    MenuItem menuItem;

    //FOR TESTING ONLY, DELETE AFTER
    public bool isCorrect;

    private void OnEnable()
    {
        customer = FindObjectOfType<CustomerStateManager>();

        if (IsCorrectAnswer())
        {
            StateManager.instance.SwitchStates(new FreeRoamingState());
        }
        else
        {
            Debug.Log("incorrect, try again!");
        }
        this.enabled = false;
    }

    /// <summary>
    /// Gets the menu item from the players chosen option and stores it 
    /// </summary>
    /// <param name="ID"></param>
    public void ReceiveMenuItem(MenuItem item)
    {
        menuItem = item;
    }

    /// <summary>
    /// returns True if the customer's id and the menuitems id match, otherwise returns False
    /// </summary>
    /// <returns>bool representing if ids are matching</returns>
    public bool IsCorrectAnswer()
    {
        // return customer.ID == menuItem.itemID << thats what this should be once customer dependancy is handled 
        return isCorrect;
    }
}
