using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScoreTracker : MonoBehaviour
{

    private int bugsKilled = 0;
    private int customersServed = 0;
    private int buttonPressed = 0;
    private float buttonPressTime = 0f;

    [SerializeField] private int scoreMultiplier = 1000;
    [SerializeField] private TMP_Text scoreBoard;

    private int totalScore;


    private void OnEnable()
    {
        ActionList.OnButtonReleased += AddButtonPress;
        ActionList.OnCustomerLeft += AddCustomerServed;
        ActionList.OnBugKilled += AddBugsKilled;
    }

    private void AddCustomerServed(ActionType action)
    {
        customersServed++;
        ScoreUpdate();
    }
    private void AddButtonPress(float buttonTime)
    {
        buttonPressTime += buttonTime;
        buttonPressed++;
        ScoreUpdate();
    }

    private void AddBugsKilled()
    {
        bugsKilled++;
        ScoreUpdate();
    }


    private void ScoreUpdate()
    {
        totalScore = (int)((bugsKilled + customersServed + buttonPressed + (buttonPressTime/5f)) * scoreMultiplier);
        scoreBoard.text = "SCORE: " + totalScore.ToString();
    }



    private void OnDisable()
    {
        ActionList.OnButtonReleased -= AddButtonPress;
        ActionList.OnCustomerLeft -= AddCustomerServed;
        ActionList.OnBugKilled -= AddBugsKilled;
    }
}
