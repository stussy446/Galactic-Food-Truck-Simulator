using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


    public class TranslatorFunction : MonoBehaviour
    {

        [SerializeField] private TMP_Text inputText;
        [SerializeField] private TMP_Text outputText;
        private int lineID, languageID;


        private int languageIndex = 1;



        private void OnEnable()
        {
            TranslateActions.OnDialClicked += RunTranslator;
            TranslateActions.OnOrderSwitch += OnRandomLineClicked;
        }


        void RunTranslator()
        {

            languageIndex++;

            if (languageIndex > SqliteScript.GetSize("LangID", "LangIndex"))
            {
                languageIndex = 1;
            }

            outputText.text = SqliteScript.GetLine(languageIndex, lineID);


        }

        public void OnRandomLineClicked()
        {
            lineID = Random.Range(1, SqliteScript.GetSize("LineID", "OrderTable") + 1);

            languageID = Random.Range(1, SqliteScript.GetSize("LangID", "LangIndex") + 1);
            languageIndex = languageID;

            inputText.text = SqliteScript.GetLine(languageID, lineID);
            outputText.text = SqliteScript.GetLine(languageIndex, lineID);

            TranslateActions.OnNewOrder(this);
        }

        private void OnDisable()
        {
            TranslateActions.OnDialClicked -= RunTranslator;
            TranslateActions.OnOrderSwitch -= OnRandomLineClicked;
        }

        public int GetLanguageID()
        {
            return languageID;
        }


}

