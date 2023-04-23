using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    [SerializeField] private List<TMP_Text> topTen;
    [SerializeField] private GameObject highScoreWindow;
    [SerializeField] private TMP_Text nameInput;
    [SerializeField] private HighScoreTracker highScoreTracker;

    private List<string> highScoreList;
    private string fillerLine = "BLANK";
    private int thresholdScore;
    private int currentScore;

    /// <summary>
    /// Enables the scoreboard with the appropriate list of high scores
    /// </summary>
    public void EnableScoreboard()
    {
        currentScore = highScoreTracker.GetTotalScore();
        highScoreTracker.RemoveScore();
        gameObject.SetActive(true);
        highScoreWindow.SetActive(false);
        GetHighScores(10);
        PopulateList();

        if (currentScore > thresholdScore)
        {
            EnterNewHighScore();
        }
    }

    /// <summary>
    /// Get a list of a configurable amount of players with the highest scores 
    /// </summary>
    /// <param name="limit">int</param>
    public void GetHighScores(int limit)
    {
        highScoreList = SqliteScript.GetScoreTable(limit);

        if (highScoreList.Count < 10)
        {
            thresholdScore = 0;
            return;
        }

        string[] scoreLine = highScoreList[highScoreList.Count - 1].Split(',');
        thresholdScore = Int32.Parse(scoreLine[1]);
    }

    /// <summary>
    /// populates the high score list
    /// </summary>
    private void PopulateList()
    {
        string[] scoreLine;

        for(int i = 0; i < topTen.Count; i++)
        {
            if (i < highScoreList.Count)
            {
                scoreLine = highScoreList[i].Split(',');
                topTen[i].text = scoreLine[0] + ". . . . . . . . . . . ." + scoreLine[1];
            }
            else
            {
                topTen[i].text = fillerLine;
            }
        }
    }

    /// <summary>
    /// Enables the high score window
    /// </summary>
    private void EnterNewHighScore()
    {
        highScoreWindow.SetActive(true); 
    }

    /// <summary>
    /// Inserts new high score entry into the high score table
    /// </summary>
    public void OnConfirmClicked()
    {
        string inputLine = "'" + nameInput.text + "','" + currentScore.ToString() + "'";

        highScoreWindow.SetActive(false);
        SqliteScript.InsertScore(inputLine);
        GetHighScores(10);
        PopulateList();
    }
}
