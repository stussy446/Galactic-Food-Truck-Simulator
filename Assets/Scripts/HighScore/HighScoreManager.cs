using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScoreManager : MonoBehaviour
{

    [SerializeField] private List<TMP_Text> topTen;
    [SerializeField] private GameObject highScoreWindow;
    [SerializeField] private TMP_Text nameInput;
    private List<string> highScoreList;
    private string fillerLine = "BLANK";
    private int thresholdScore;
    private string newHighScoreEntry;

    private int currentScore = 99854;


    // Start is called before the first frame update
    void Start()
    {
        highScoreWindow.SetActive(false);
        GetHighScores(10);
        PopulateList();
        EnterNewHighScore();
    }

    public void GetHighScores(int limit)
    {
        highScoreList = SqliteScript.GetScoreTable(limit);
        string[] scoreLine = highScoreList[highScoreList.Count - 1].Split(',');
        thresholdScore = Int32.Parse(scoreLine[1]);
    }

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

    private void EnterNewHighScore()
    {
        highScoreWindow.SetActive(true); 
    }

    public void OnConfirmClicked()
    {
        string inputLine = "'" + nameInput.text + "','" + currentScore.ToString() + "'";

        highScoreWindow.SetActive(false);
        SqliteScript.InsertScore(inputLine);
        GetHighScores(10);
        PopulateList();
    }
}
