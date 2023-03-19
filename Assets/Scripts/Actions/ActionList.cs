using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Holds all the possible actions the player can take.
/// </summary>
public static class ActionList
{
    public static Action<ActionType> OnEnteredButtonPressing;
    public static Action<ActionType> OnPlayerCloseToLosing;
    public static Action<ActionType> OnEnteredFoodReplicator;
    public static Action<ActionType> OnDoneReplicatingFood;
    public static Action<ActionType> OnCustomerReceivedFood;
    public static Action<ActionType> OnTriedInteractingWithInactiveButton;
    public static Action<ActionType> OnEnteredTranslator;
    public static Action<ActionType> OnExitedTranslator;
    public static Action<ActionType> OnCustomerArrived;
    public static Action<ActionType> OnCustomerOrdered;
    public static Action<ActionType> OnCustomerLeft;

    /// <summary>
    /// Adds all possible player actions to one list. Makes accessing all of them 
    /// easier in other classes.
    /// </summary>
    /// <returns></returns>
    public static List<Action<ActionType>> GetAllActions()
    {
        List<Action<ActionType>> allActions = new List<Action<ActionType>>();
        allActions.Add(OnEnteredButtonPressing);
        allActions.Add(OnPlayerCloseToLosing);
        allActions.Add(OnEnteredTranslator);
        allActions.Add(OnDoneReplicatingFood);
        allActions.Add(OnCustomerReceivedFood);
        allActions.Add(OnTriedInteractingWithInactiveButton);
        allActions.Add(OnEnteredTranslator);
        allActions.Add(OnExitedTranslator);
        allActions.Add(OnCustomerArrived);
        allActions.Add(OnCustomerOrdered);
        allActions.Add(OnCustomerLeft);
        return allActions;
    }

}
