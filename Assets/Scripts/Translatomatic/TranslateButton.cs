using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateButton : MonoBehaviour
{
    [SerializeField] private Vector3 dialAngle;
    private Quaternion originalRotation;

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
        transform.Rotate(dialAngle);
        TranslateActions.OnDialClicked();
    }

    private void SetDial(TranslatorFunction translate)
    {
        transform.rotation = originalRotation;
        transform.Rotate(dialAngle * translate.GetLanguageID());
    }

    private void OnDisable()
    {
        TranslateActions.OnNewOrder -= SetDial;
    }
}
