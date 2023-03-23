using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    MenuItem menuItem;
    CustomerStateManager customer; // TODO: this feels like there should be a Customer class we can grab here rather than the state manager 
    public bool isCorrect; // should be private after customer id is implemented

    public bool IsCorrect { 
        get 
        {
            // return menuItem.ItemID == customer.ID;  <----- this is what it should be after id is implemented with customer 
            return isCorrect;
        }
    }

    public void ReceiveOrderItems(MenuItem item)
    {
        menuItem = item;
        FindCustomer();
    }

    private void FindCustomer()
    {
        customer = FindObjectOfType<CustomerStateManager>();
        if (customer == null)
        {
            Debug.Log("No customer was found");
        }
    }


}
