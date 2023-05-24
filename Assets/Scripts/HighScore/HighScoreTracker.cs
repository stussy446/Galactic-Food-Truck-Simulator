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

    /// <summary>
    /// increases count of the amount of wrong orders guessed and updates the score
    /// </summary>
    private void AddWrongOrderPress()
    {
        wrongOrder++;
        ScoreUpdate();
    }

    /// <summary>
    /// increases the count of customers served and updates the score
    /// </summary>
    /// <param name="action"></param>
    private void AddCustomerServed(ActionType action)
    {
        customersServed++;
        ScoreUpdate();
    }

    /// <summary>
    /// increases the amount of time the button has been pressed and the count of times the button has been pressed, and updates score
    /// </summary>
    /// <param name="buttonTime">float</param>
    private void AddButtonPress(float buttonTime)
    {
        buttonPressTime += buttonTime;
        buttonPressed++;
        ScoreUpdate();
    }

    /// <summary>
    /// increases the count of bugs killed and increases the score
    /// </summary>
    private void AddBugsKilled()
    {
        bugsKilled++;
        ScoreUpdate();
    }

    /// <summary>
    /// Updates the score based bugs killed, times/amount the button is pressed, customers served, and the amount of times the player guessed wrong
    /// </summary>
    private void ScoreUpdate()
    {
        totalScore = (int)(((bugsKilled*bugMultiplier) + customersServed + ((wrongOrder+buttonPressed)*buttonMultiplier) + (buttonPressTime*timeMultiplier)) * scoreMultiplier);
        scoreBoard.text = "SCORE: " + totalScore.ToString();
    }

    /// <summary>
    /// Disables the high score board 
    /// </summary>
    public void RemoveScore()
    {
        gameObject.SetActive(false);
    }
    
    /// <summary>
    /// Get the total score of the game session
    /// </summary>
    /// <returns>int</returns>
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
