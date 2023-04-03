using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TextManipulator : MonoBehaviour
{
    [SerializeField] TMP_Text titleText;

    [Header("Animation Configs")]
    [SerializeField] float amplitude;
    [SerializeField] float frequency;
    [SerializeField] float offset;
    [SerializeField] float animationDelay;

    private bool delayComplete;

    private void OnEnable()
    {
        StartCoroutine(DelayForSwitch());
    }

    private void Update()
    {
        if (delayComplete)
        {
            float sine = CalculateSine() + offset;
            titleText.transform.localScale = new Vector3(sine, sine, 0f);
        }
    }

    private float CalculateSine()
    {
        return Mathf.Sin(Time.time * frequency) * amplitude;
    }
    private IEnumerator DelayForSwitch()
    {
        yield return new WaitForSeconds(animationDelay);
        delayComplete = true;
    }

}
