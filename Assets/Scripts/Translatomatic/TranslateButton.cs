using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateButton : MonoBehaviour
{
    [SerializeField] private Vector3 dialAngle = new Vector3(0, 120f, 0);


    void OnMouseDown()
    {
        transform.Rotate(dialAngle);
        TranslateActions.OnDialClicked();
    }
}
