using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TranslateButton : MonoBehaviour
{

    [SerializeField] private TMP_Text inputText;
    [SerializeField] private TMP_Text outputText;

    [SerializeField] private Vector3 dialAngle;
    private Quaternion originalRotation;
    private bool buttonEnable = false;

    private void OnEnable()
    {
        TranslateActions.OnNewOrder += SetDial;
    }
    private void Start()
    {
        dialAngle.y = 360 / (SqliteScript.GetSize("LangID", "LangIndex"));
        originalRotation = transform.rotation;
    }
    void OnMouseDown()
    {
        if(!buttonEnable)
        {
            return;
        }

        transform.Rotate(dialAngle);
        TranslateActions.OnDialClicked();
    }

    private void SetDial(TranslatorFunction translate)
    {
        buttonEnable = true;
        transform.rotation = originalRotation;
        transform.Rotate(dialAngle * translate.GetLanguageID());
    }

    public void SetInputText(string textString)
    {
        inputText.text = textString;
    }
    public void SetOutputText(string textString)
    {
        outputText.text = textString;
    }

    private void OnDisable()
    {
        TranslateActions.OnNewOrder -= SetDial;
    }
}
