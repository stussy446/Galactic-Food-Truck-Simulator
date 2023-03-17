using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerFinder : MonoBehaviour
{
    private void Awake()
    {
        Canvas canvas = GetComponent<Canvas>();
        canvas.worldCamera = Camera.main;
    }
}
