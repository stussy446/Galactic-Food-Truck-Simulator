using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stomping : MonoBehaviour
{
    private const string PLAYER_TAG = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(PLAYER_TAG))
        {
            Destroy(gameObject);
        }
    }
}
