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

    //Listen for order received
    private void OnEnable()
    {
        TranslateActions.OnNewOrder += SetDial;
    }

    //Set up dial segments based on amount of different languages set in database
    private void Start()
    {
        dialAngle.z = 360 / (SqliteScript.GetSize("LangID", "LangIndex"));
        originalRotation = transform.rotation;
    }

    //rotate button and triggers action listend to by translator functions class
    void OnMouseDown()
    {
        if(!buttonEnable)
        {
            return;
        }

        transform.Rotate(dialAngle);
        TranslateActions.OnDialClicked();
    }

    //Set initial rotation of dial and default visual output for a given order id
    private void SetDial(TranslatorFunction translate)
    {
        buttonEnable = true;
        transform.rotation = originalRotation;
        transform.Rotate(dialAngle * translate.GetLanguageID());
    }

    //Set the text of the translator input text box
    public void SetInputText(string textString)
    {
        inputText.text = textString;
    }

    //Set the text of the translator output text box
    public void SetOutputText(string textString)
    {
        outputText.text = textString;
    }

    //Stop listening to actions
    private void OnDisable()
    {
        TranslateActions.OnNewOrder -= SetDial;
    }
}
