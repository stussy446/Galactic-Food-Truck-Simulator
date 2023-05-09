using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0, 0.002f, 0);
    }
}
