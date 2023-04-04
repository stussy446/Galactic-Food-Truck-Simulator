using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    [SerializeField] private float destroytime = 2f;
    [SerializeField] private ParticleSystem particle;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyObject", destroytime);
    }

    void OnEnable()
    {
        Invoke("DestroyObject", destroytime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DestroyObject()
    {
        particle.Stop();
        particle.Clear();
        gameObject.SetActive(false);
    }
}
