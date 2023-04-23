using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraRenderer : MonoBehaviour
{
    [SerializeField] private float fps = 10f;
    private float totalTime = 0f;
    private Camera choppyCam;

    private void Start()
    {
        choppyCam = GetComponent<Camera>();
        choppyCam.enabled = false;
    }

    private void Update()
    {
        totalTime += Time.deltaTime;

        if(totalTime < 1 / fps)
        {
            return;
        }

        totalTime = 0f;
        choppyCam.Render();
    }
}
