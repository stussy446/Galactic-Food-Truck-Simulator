using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TranslatorFunction : MonoBehaviour
{

    [SerializeField] private TMP_Text inputText;
    [SerializeField] private TMP_Text outputText;
    private int lineID, languageID;

    
    private int languageIndex = 0;



    private void OnEnable()
    {
        TranslateActions.OnDialClicked += RunTranslator;
    }


    void RunTranslator()
    {
        if(languageIndex >= LinesDatabase.Instance.GetLanguageSize())
        {
            languageIndex = 0;
        }
        if(languageIndex == languageID)
        {
            outputText.text = LinesDatabase.Instance.GetLine(0, lineID);
        }
        else
        {
            if (languageIndex == 0)
                outputText.text = "Gibberish";
            else
                outputText.text = LinesDatabase.Instance.GetLine(languageIndex, lineID);
        }
        languageIndex++;
    }

    public void OnRandomLineClicked()
    {
        lineID = Random.Range(0, LinesDatabase.Instance.GetLineSize());

        languageID = Random.Range(0, LinesDatabase.Instance.GetLanguageSize());

        inputText.text = LinesDatabase.Instance.GetLine(languageID, lineID);
    }

    private void OnDisable()
    {
        TranslateActions.OnDialClicked -= RunTranslator;
    }


}
