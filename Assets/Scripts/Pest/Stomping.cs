using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using EZCameraShake;

public class Stomping : MonoBehaviour
{
    private const string PLAYER_TAG = "Player";

    [Header("Bug Camera Shake Impact Configs")]
    [SerializeField] float shakeMagnitude;
    [SerializeField] float shakeRoughness;
    [SerializeField] float shakeFadeInTime;
    [SerializeField] float shakeFadeOutTime;

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

    /// <summary>
    /// Destroys the bug
    /// </summary>
    private void Squish()
    {
        Destroy(gameObject);
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
