using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class TranslatorFunction : MonoBehaviour
{

        [SerializeField] private TranslateButton translatorUI;
        private int lineID, languageID;


        private int languageIndex = 1;



        private void OnEnable()
        {
            TranslateActions.OnDialClicked += RunTranslator;
            TranslateActions.OnOrderSwitch += OnRandomLineClicked;
            TranslateActions.OnReceiveOrder += OnOrderReceived;
        }


        void RunTranslator()
        {

            languageIndex++;

            if (languageIndex > SqliteScript.GetSize("LangID", "LangIndex"))
            {
                languageIndex = 1;
            }

            translatorUI.SetOutputText(SqliteScript.GetLine(languageIndex, lineID));



        }

        public void OnOrderReceived(int lang, int line)
        {
            lineID = line;
            languageID = lang;
            languageIndex = lang;
            translatorUI.SetInputText(SqliteScript.GetLine(languageID, lineID));
            translatorUI.SetOutputText(SqliteScript.GetLine(languageIndex, lineID));

            TranslateActions.OnNewOrder(this);
        }

        public void OnRandomLineClicked()
        {
            lineID = Random.Range(1, SqliteScript.GetSize("LineID", "OrderTable") + 1);

            languageID = Random.Range(1, SqliteScript.GetSize("LangID", "LangIndex") + 1);
            languageIndex = languageID;

            translatorUI.SetInputText(SqliteScript.GetLine(languageID, lineID));
            translatorUI.SetOutputText(SqliteScript.GetLine(languageIndex, lineID));

            TranslateActions.OnNewOrder(this);
        }

        private void OnDisable()
        {
            TranslateActions.OnDialClicked -= RunTranslator;
            TranslateActions.OnOrderSwitch -= OnRandomLineClicked;
            TranslateActions.OnReceiveOrder -= OnOrderReceived;
    }

        public int GetLanguageID()
        {
            return languageID;
        }


}

