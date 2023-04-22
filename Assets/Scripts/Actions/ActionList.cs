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
    public static Action<ActionType> OnButtonPressed;
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
    
    public static Action OnBugKilled;
    public static Action<float> OnButtonReleased;
    public static Action OnWrongReplicatorChoice;

}
