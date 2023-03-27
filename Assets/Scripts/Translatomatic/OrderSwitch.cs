using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderSwitch : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var lineID = Random.Range(1, SqliteScript.GetSize("LineID", "OrderTable") + 1);

        var languageID = Random.Range(1, SqliteScript.GetSize("LangID", "LangIndex") + 1);

        TranslateActions.OnReceiveOrder(languageID,lineID);
    }
}
