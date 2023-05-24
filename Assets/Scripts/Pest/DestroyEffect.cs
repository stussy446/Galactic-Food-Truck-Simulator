using UnityEngine;
using UnityEngine.VFX;

public class DestroyEffect : MonoBehaviour
{
    [SerializeField] private float destroytime = 1f;
    [SerializeField] private VisualEffect blood;

    private void OnEnable()
    {
        blood.Play();
        Invoke("DestroyObject", destroytime);
    }

    private void DestroyObject()
    {
        gameObject.SetActive(false);
    }
}
