using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    MenuItem menuItem;
    Customer customer; 

    public bool IsCorrect { 
        get 
        {
            if (!IsCorrectChoice())
            {
                return false;
            }

            ResetOrder();
            ActionList.OnDoneReplicatingFood?.Invoke(ActionType.DoneReplicatingFood);
            return true;
        }
    }

    public void ReceiveOrderItems(MenuItem item)
    {
        menuItem = item;
        FindCustomer();
    }

    private void FindCustomer()
    {
        customer = FindObjectOfType<Customer>();
        if (customer == null)
        {
            Debug.Log("No customer was found");
        }
    }

    private void ResetOrder()
    {
        menuItem = null;
        customer = null;
    }

    private bool ChoiceNotReady()
    {
        if(menuItem == null || customer == null)
        {
            return true;
        }

        return false;
    }

    private bool IsCorrectChoice()
    {
        if (ChoiceNotReady())
        {
            return false;
        }

        return menuItem.ItemID == customer.OrderID;
    }


}
