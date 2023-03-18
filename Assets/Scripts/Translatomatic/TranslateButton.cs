using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateButton : MonoBehaviour
{
    [SerializeField] private Vector3 dialAngle = new Vector3(0, 120f, 0);

    private void OnEnable()
    {
        TranslateActions.OnNewOrder += SetDial;
    }
    private void Start()
    {
        dialAngle.y = 360 / LinesDatabase.Instance.GetLanguageSize();
    }
    void OnMouseDown()
    {
        transform.Rotate(dialAngle);
        TranslateActions.OnDialClicked();
    }

    private void SetDial(TranslatorFunction translate)
    {
        transform.rotation = Quaternion.identity;
        transform.Rotate(dialAngle * translate.GetLanguageID());
    }

    private void OnDisable()
    {
        TranslateActions.OnNewOrder -= SetDial;
    }
}
