using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class Stomping : MonoBehaviour
{
    private const string PLAYER_TAG = "Player";
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
            CameraShaker.Instance.ShakeOnce(shakeMagnitude, shakeRoughness, shakeFadeInTime, shakeFadeOutTime);
            Destroy(gameObject);
        }
    }
}
