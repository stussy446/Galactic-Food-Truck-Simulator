using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using static UnityEngine.ParticleSystem;

public class DestroyEffect : MonoBehaviour
{
    [SerializeField] private float destroytime = 1f;
    [SerializeField] private VisualEffect blood;

    void OnEnable()
    {
        blood.Play();
        Invoke("DestroyObject", destroytime);
    }

    private void DestroyObject()
    {
        gameObject.SetActive(false);
    }
}
