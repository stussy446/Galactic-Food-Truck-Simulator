using System.Collections;
using UnityEngine;

public class BoxOpener : MonoBehaviour
{
    private Quaternion openRotation;
    private Vector3 closeRotation = new Vector3(-24, 0, 0);

    private void Start()
    {
        openRotation = transform.localRotation;
    }

    /// <summary>
    /// Smoothly opens the box
    /// </summary>
    /// <returns></returns>
    private IEnumerator OpenBoxCoroutine() 
    {
        float factor = 0;
        while (factor < 1)
        {
            transform.localRotation = Quaternion.Lerp(transform.localRotation, openRotation, factor);
            factor += Time.deltaTime;
            yield return null;
        }
        transform.localRotation = openRotation;
    }

    /// <summary>
    /// Smoothly closes the box
    /// </summary>
    /// <returns></returns>
    private IEnumerator CloseBoxCoroutine() 
    {
        float factor = 0;
        while (factor < 1)
        {
            transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(closeRotation), factor);
            factor += Time.deltaTime;
            yield return null;
        }
        transform.localRotation = Quaternion.Euler(closeRotation);

    }

    public void OpenBox()
    {
        StartCoroutine(OpenBoxCoroutine());
    }

    public void CloseBox()
    {
        StartCoroutine(CloseBoxCoroutine());
        StateManager.instance.SwitchStates(StateManager.instance.freeRoamingState);

    }
}
