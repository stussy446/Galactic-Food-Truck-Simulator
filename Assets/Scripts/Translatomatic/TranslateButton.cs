using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class TranslateButton : MonoBehaviour
{

    [SerializeField] private TMP_Text inputText;
    [SerializeField] private TMP_Text outputText;

    [SerializeField] private Vector3 dialAngle;
    private Quaternion originalRotation;
    private bool buttonEnable = false;

    [SerializeField]
    private Dictionary<string, string> translatorLines = new Dictionary<string, string>()
    {
        {"Who decided English would be Galactic common?", "Why don't you go and ask the AI overlord?" },
        {"Hey man, looking a bit on tilt over there.", "Shut up and do your job." },
        {"Oh, I hope we get to translate some Klingon today.", "Every time you speak, I feel like today is a good day for you to die." },
        {"Aren't you worried one of them critters might crawl into your exposed panel?", "ASSUMING DIRECT CONTROL." },
        {"I am fluent in over 6 million forms of communication.", "Pipe down before we get sued by the mouse." },
        {"Doesn't that massive space battle next to us make you nervous?", "I hope a stray bullet hits your screen."},
        {"Remember when they used to call us Babel Fish? Who came up with that?", "Stay on task, you yappy yahoo!" }
    };

    //Listen for order received
    private void OnEnable()
    {
        TranslateActions.OnNewOrder += SetDial;
        ActionList.OnCustomerLeft += ResetScreen;
    }

    //Set up dial segments based on amount of different languages set in database
    private void Start()
    {
        dialAngle.z = 360 / (SqliteScript.GetSize("LangID", "LangIndex"));
        originalRotation = transform.rotation;
    }

    /// <summary>
    /// rotate button and triggers action listend to by translator functions class
    /// </summary>
    private void OnMouseDown()
    {
        if(!buttonEnable)
        {
            return;
        }

        transform.Rotate(dialAngle);
        TranslateActions.OnDialClicked();
    }

    /// <summary>
    /// Set initial rotation of dial and default visual output for a given order id
    /// </summary>
    /// <param name="translate"></param>
    private void SetDial(TranslatorFunction translate)
    {
        buttonEnable = true;
        transform.rotation = originalRotation;
        transform.Rotate(dialAngle * translate.GetLanguageID());
    }

    /// <summary>
    /// Set the text of the translator input text box
    /// </summary>
    /// <param name="textString">string</param>
    public void SetInputText(string textString)
    {
        inputText.text = textString;
    }

    /// <summary>
    /// Set the text of the translator output text box
    /// </summary>
    /// <param name="textString">string</param>
    public void SetOutputText(string textString)
    {
        outputText.text = textString;
    }

    /// <summary>
    /// Resets the tranlsator's screen
    /// </summary>
    /// <param name="type"></param>
    private void ResetScreen(ActionType type)
    {
        if (translatorLines.Count <= 0)
        {
            inputText.text = "Translator is ready.";
            outputText.text = "Or is it?";
        }
        else
        {
            int index = Random.Range(0, translatorLines.Count);
            inputText.text = translatorLines.ElementAt(index).Key;
            outputText.text = translatorLines.ElementAt(index).Value;
        }
    }

    //Stop listening to actions
    private void OnDisable()
    {
        TranslateActions.OnNewOrder -= SetDial;
        ActionList.OnCustomerLeft -= ResetScreen;
    }
}
