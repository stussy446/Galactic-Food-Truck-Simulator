using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    [SerializeField] private float destroytime = 2f;
    [SerializeField] private ParticleSystem particle;

    private void Start()
    {
        Invoke("DestroyObject", destroytime);
    }

    private void OnEnable()
    {
        Invoke("DestroyObject", destroytime);
    }

    /// <summary>
    /// Stops and clears currently playing particles and set game object to inactive
    /// </summary>
    private void DestroyObject()
    {
        particle.Stop();
        particle.Clear();
        gameObject.SetActive(false);
    }
}
