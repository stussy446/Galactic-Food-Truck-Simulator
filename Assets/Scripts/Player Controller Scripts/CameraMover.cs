using UnityEngine;

public class CameraMover : MonoBehaviour
{
    const string PlayerCameraTag = "Player";

    [Header("Mouse Sensitivity")]
    [SerializeField] float sensitivityX = 8f;
    [SerializeField] float sensitivityY = 8f;

    [Header("Camera and Camera Bounds")]
    [SerializeField] Transform playerCamera;
    [SerializeField] float xClamp = 85f;
    float xRotation = 0f;

    float mouseX;
    float mouseY;

    private void Awake()
    {
        RemoveExtraCameras();
    }

    /// <summary>
    /// Removes default main camera from scene to ensure the players fps camera is the one used
    /// </summary>
    private void RemoveExtraCameras()
    {
        Camera[] cameras = FindObjectsOfType<Camera>();
        foreach (Camera camera in cameras)
        {
            if (!camera.CompareTag(PlayerCameraTag))
            {
                Destroy(camera.gameObject);
            }
        }
    }

    private void Update()
    {
        RotateHorizontally();
        RotateVertically();
    }

    /// <summary>
    /// Handles rotating the camera around the y axis based on the received mouseX input
    /// </summary>
    private void RotateHorizontally()
    {
        transform.Rotate(Vector3.up, mouseX * Time.deltaTime);
    }

    /// <summary>
    /// Handles rotating the camera around the x axis based on the received mouseY input
    /// </summary>
    private void RotateVertically()
    {
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -xClamp, xClamp);

        Vector3 targetRotation = transform.eulerAngles;
        targetRotation.x = xRotation;
        playerCamera.eulerAngles = targetRotation;
    }

    /// <summary>
    /// Receives a Vector2 representing the mouses input and stores values into mouseX and mouseY fields
    /// </summary>
    /// <param name="mouseInput">Vector2</param>
    public void ReceiveInput(Vector2 mouseInput)
    {
        mouseX = mouseInput.x * sensitivityX;
        mouseY = mouseInput.y * sensitivityY;
    }

}
