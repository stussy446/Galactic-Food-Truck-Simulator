using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class TranslatorFunction : MonoBehaviour
{

        [SerializeField] private TranslateButton translatorUI;
        [SerializeField] private AudioSource translatorSpeaker;
        private AudioClip[] orderclips;
        [SerializeField] AudioClip defaultClip;
        private int lineID, languageID;
        

        private int languageIndex = 1;


        //Listen for actions which trigger the translator to work ie. receiving an order
        private void OnEnable()
        {
            TranslateActions.OnDialClicked += RunTranslator;
            TranslateActions.OnReceiveOrder += OnOrderReceived;
        }

        //Changes translator output by querying database for the equivalent line in different language
        void RunTranslator()
        {

            languageIndex++;

            if (languageIndex > SqliteScript.GetSize("LangID", "LangIndex"))
            {
                languageIndex = 1;
            }

            translatorUI.SetOutputText(SqliteScript.GetLine(languageIndex, lineID));

            translatorSpeaker.Stop();
            if(languageIndex == 1)
            {
                translatorSpeaker.clip = orderclips[0];
                
            }
            else if (languageIndex == 4)
            {
                translatorSpeaker.clip = orderclips[1];

            }
            else
            {
                translatorSpeaker.clip = defaultClip;
            }
            translatorSpeaker.Play();



        }
        
        //Sets up translator by selecting the correct line from database as well as the starting language
        public void OnOrderReceived(int lang, int line)
        {
            lineID = line;
            languageID = lang;
            languageIndex = lang;
            translatorUI.SetInputText(SqliteScript.GetLine(languageID, lineID));
            translatorUI.SetOutputText(SqliteScript.GetLine(languageIndex, lineID));
            orderclips = Resources.LoadAll<AudioClip>($"TranslateLines/order{lineID}");
            foreach (var clip in orderclips)
            {
                Debug.Log(clip.name);
            }
            TranslateActions.OnNewOrder(this);
        }


        //stop listening to actions on disable
        private void OnDisable()
        {
            TranslateActions.OnDialClicked -= RunTranslator;
            TranslateActions.OnReceiveOrder -= OnOrderReceived;
        }

        //returns the language ID as an INT
        public int GetLanguageID()
        {
            return languageID;
        }


}

