using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxOpener : MonoBehaviour
{
    private Vector3 openRotation = new Vector3(90, 90, 0);
    private Vector3 closeRotation = new Vector3(0, 90, 0);

    private IEnumerator OpenBoxCoroutine() 
    {
        float factor = 15;
        while (factor > 0)
        {
            transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(openRotation), factor);
            factor -= Time.deltaTime/50;
            yield return null;
        }
        
    }
    private IEnumerator CloseBoxCoroutine() 
    {
        float factor = 15;
        while (factor > 0)
        {
            transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(closeRotation), factor);
            factor -= Time.deltaTime/50;
            yield return null;
        }
    }

    public void OpenBox()
    {
        StartCoroutine(OpenBoxCoroutine());
        transform.rotation = Quaternion.Euler(openRotation);
    }

    public void CloseBox()
    {
        StartCoroutine(CloseBoxCoroutine());
        transform.rotation = Quaternion.Euler(closeRotation);
    }
}
