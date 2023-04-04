using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Timeline;
using UnityEngine.Playables;

public class TextShrinker : MonoBehaviour
{
    [SerializeField] TMP_Text titleText;
    [SerializeField] float minFontSize = 180;

    PlayableDirector director;
    
    
    private void Awake()
    {
        director = FindObjectOfType<PlayableDirector>();
        if (director == null)
        {
            Debug.Log("no director found");
        }
    }

    public void Shrink()
    {
        Debug.Log("hello");
        while(titleText.fontSize > minFontSize)
        {
            titleText.fontSize -= .0001f;
        }
    }
}


