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
        
        languageIndex++;

        if (languageIndex >= LinesDatabase.Instance.GetLanguageSize())
        {
            languageIndex = 0;
        }

        outputText.text = LinesDatabase.Instance.GetLine(languageIndex, lineID);
        
        
    }

    public void OnRandomLineClicked()
    {
        lineID = Random.Range(0, LinesDatabase.Instance.GetLineSize());

        languageID = Random.Range(0, LinesDatabase.Instance.GetLanguageSize());
        languageIndex = languageID;

        inputText.text = LinesDatabase.Instance.GetLine(languageID, lineID);
        outputText.text = LinesDatabase.Instance.GetLine(languageIndex, lineID);

        TranslateActions.OnNewOrder(this);
    }

    private void OnDisable()
    {
        TranslateActions.OnDialClicked -= RunTranslator;
    }

    public int GetLanguageID()
    {
        return languageID;
    }


}
