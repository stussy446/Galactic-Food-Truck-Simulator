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
    private int wrongOrder = 0;

    [SerializeField] private int scoreMultiplier = 1000;
    [SerializeField] private float buttonMultiplier = -0.1f;
    [SerializeField] private float bugMultiplier = 0.5f;
    [SerializeField] private float timeMultiplier = 0.2f;
    [SerializeField] private TMP_Text scoreBoard;

    private int totalScore;


    private void OnEnable()
    {
        ActionList.OnButtonReleased += AddButtonPress;
        ActionList.OnCustomerLeft += AddCustomerServed;
        ActionList.OnBugKilled += AddBugsKilled;
        ActionList.OnWrongReplicatorChoice += AddWrongOrderPress;
    }

    private void AddWrongOrderPress()
    {
        wrongOrder++;
        ScoreUpdate();
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
        totalScore = (int)(((bugsKilled*bugMultiplier) + customersServed + (wrongOrder+buttonPressed*buttonMultiplier) + (buttonPressTime*timeMultiplier)) * scoreMultiplier);
        scoreBoard.text = "SCORE: " + totalScore.ToString();
    }

    public void RemoveScore()
    {
        gameObject.SetActive(false);
    }

    public int GetTotalScore()
    {
        return totalScore;
    }

    private void OnDisable()
    {
        ActionList.OnButtonReleased -= AddButtonPress;
        ActionList.OnCustomerLeft -= AddCustomerServed;
        ActionList.OnBugKilled -= AddBugsKilled;
        ActionList.OnWrongReplicatorChoice -= AddWrongOrderPress;
    }
}
