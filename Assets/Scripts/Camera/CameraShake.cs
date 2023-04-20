using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    // Transform of the camera to shake. Grabs the gameObject's transform
    // if null.
    [SerializeField] Transform camTransform;

    // How long the object should shake for.
    [SerializeField] float shakeDuration;

    // Amplitude of the shake. A larger value shakes the camera harder.
    [SerializeField] float shakeAmount = 0.7f;
    [SerializeField] float decreaseFactor = 1.0f;

    Vector3 originalPos;
    float startingShakeDuration;

    void Awake()
    {
        startingShakeDuration = shakeDuration;

        if (camTransform == null)
        {
            camTransform = GetComponent(typeof(Transform)) as Transform;
        }
    }

    void OnEnable()
    {
        originalPos = camTransform.localPosition;
        ActionList.OnBugKilled += ShakeCamera;
    }

    private void OnDisable()
    {
        ActionList.OnBugKilled -= ShakeCamera;
    }

    public void ShakeCamera()
    {
        StartCoroutine(Shake());
    }

    private IEnumerator Shake()
    {
        while(shakeDuration > 0)
        {
            camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
            shakeDuration -= Time.deltaTime * decreaseFactor;

            yield return null;
        }
       
        camTransform.localPosition = originalPos;
        shakeDuration = startingShakeDuration;
    }
}
