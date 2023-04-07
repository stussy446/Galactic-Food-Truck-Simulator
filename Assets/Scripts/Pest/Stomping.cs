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
            Destroy(gameObject);
        }
    }
}
