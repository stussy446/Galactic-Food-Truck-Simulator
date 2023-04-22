using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stomping : MonoBehaviour
{
    private const string PLAYER_TAG = "Player";

    /// <summary>
    /// Destroys the bug when in contact with the player
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(PLAYER_TAG))
        {
            Squish();
        }
    }

    /// <summary>
    /// Destroys the bug
    /// </summary>
    private void Squish()
    {
        GameObject blood = ObjectPool.SharedInstance.GetObject("Blood");
        if(blood != null)
        {
            blood.transform.position = gameObject.transform.position;
            blood.SetActive(true);
        }
        ActionList.OnBugKilled?.Invoke();
        gameObject.SetActive(false);
    }

}
