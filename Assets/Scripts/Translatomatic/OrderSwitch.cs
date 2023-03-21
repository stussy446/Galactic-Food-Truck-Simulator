using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderSwitch : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        TranslateActions.OnOrderSwitch();
    }
}
