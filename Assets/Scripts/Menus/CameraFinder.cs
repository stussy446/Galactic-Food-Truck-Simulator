using UnityEngine;

public class CameraFinder : MonoBehaviour
{
    
    private void Awake()
    {
        FindEventCamera();
    }

    /// <summary>
    /// Finds the main camera in the scene and sets it to the canvases event camera (worldcamera == eventcamera in world space)
    /// Required due to the UI clicks depending on the canvas identifying the event camera 
    /// </summary>
    private void FindEventCamera()
    {
        Canvas canvas = GetComponent<Canvas>();
        canvas.worldCamera = Camera.main;
    }
}
