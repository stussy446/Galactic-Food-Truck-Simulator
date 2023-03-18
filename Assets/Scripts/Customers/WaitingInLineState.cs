using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaitingInLineState : MonoBehaviour
{
   // [SerializeField]
   // private TextMeshProUGUI timer;

    private float currentTime = 0f;
    private float startingTime = 10f;

  /// <summary>
  /// Sets timer to countdown amount
  /// </summary>
    void Start()
    {
        currentTime = startingTime;
    }
/// <summary>
/// Controls timer speed and countdown
/// When timer reaches 0, changes state to OrderingState
/// </summary>
    void Update()
    {
        currentTime-= 1 * Time.deltaTime;
       // timer.text = currentTime.ToString("0");    
        
        if(currentTime <= 0)
        {
          //TODO: Switch to OrderingState
        }
    }
}
