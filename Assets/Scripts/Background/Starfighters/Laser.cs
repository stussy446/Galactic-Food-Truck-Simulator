using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject explodey;
    private float boomTimer = 0.5f;

    private void OnEnable()
    {
        Invoke("Boomboom", boomTimer);
    }

    /// <summary>
    /// sets the explosion as active and plays its associated particle system
    /// </summary>
    private void Boomboom()
    {
        explodey.SetActive(true);
        explodey.GetComponentInChildren<ParticleSystem>().Play();
    }
}
