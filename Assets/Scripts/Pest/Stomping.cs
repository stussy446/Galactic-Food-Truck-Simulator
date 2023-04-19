using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using EZCameraShake;

public class Stomping : MonoBehaviour
{
    private const string PLAYER_TAG = "Player";

    private AudioSource audioSource;

    [Header("Bug Camera Shake Impact Configs")]
    [SerializeField] float shakeMagnitude;
    [SerializeField] float shakeRoughness;
    [SerializeField] float shakeFadeInTime;
    [SerializeField] float shakeFadeOutTime;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Destroys the bug when in contact with the player
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(PLAYER_TAG))
        {
            //            CameraShaker.Instance.ShakeOnce(shakeMagnitude, shakeRoughness, shakeFadeInTime, shakeFadeOutTime);
            ActionList.OnBugKilled?.Invoke();
        }
    }

    private IEnumerator SquishCoroutine()
    {
        audioSource.Play();
        while (audioSource.isPlaying)
        {
            yield return null;
        }
        Destroy(gameObject);
    }

    private void Squish()
    {
        StartCoroutine(SquishCoroutine());
    }

    private void OnEnable()
    {
        ActionList.OnBugKilled += Squish;
    }

    private void OnDisable()
    {
        ActionList.OnBugKilled -= Squish;
    }
}
