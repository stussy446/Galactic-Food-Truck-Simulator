using UnityEditor;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    private const string CAN_INTERACT_LAYER = "CanInteract";

    [Header("Mouse Sensitivity")]
    [SerializeField] float sensitivityX = 8f;
    [SerializeField] float sensitivityY = 8f;

    [Header("Camera and Camera Configs")]
    [SerializeField] Transform playerCamera;
    [SerializeField] float xClamp = 85f;
    [SerializeField] float detectionRange = 1000f;
    [SerializeField] LayerMask interactableLayer;
    [SerializeField] LayerMask itemsLayer;
    float xRotation = 0f;

    private float mouseX;
    private float mouseY;
    private Camera cam;
    private bool isPaused;
    private bool interactionButtonPressed;

    public bool IsPaused
    {
        get { return isPaused; }
        set { isPaused = value; } 
    }

    private void Awake()
    {
        cam = Camera.main;
        LockCursor();
    }

    private void Update()
    {
        if (!isPaused)
        {
            RotateHorizontally();
            RotateVertically();
        }

        ToggleCursorMode();
        Aim();
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
    /// Casts a ray from the center of the screen and detects what the player is currently looking at if its on the UI layer, should 
    /// only be used when start menu is active 
    /// </summary>
    private void Aim()
    {
        RaycastHit hit;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, detectionRange, interactableLayer))
        {
            if (interactionButtonPressed)
            {
                // switches to Fulfilling order state once the start button is pressed 
                StateManager.instance.SwitchStates(StateManager.instance.fulfillingOrderState);
            }
        }
    }

    /// <summary>
    /// Receives a Vector2 representing the mouses input and stores values into mouseX and mouseY fields
    /// </summary>
    /// <param name="mouseInput">Vector2</param>
    public void ReceiveInput(Vector2 mouseInput, bool isInteracting)
    {
        mouseX = mouseInput.x * sensitivityX;
        mouseY = mouseInput.y * sensitivityY;

        interactionButtonPressed = isInteracting;
    }

    /// <summary>
    /// locks the cursor to the game screen
    /// </summary>
    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    /// <summary>
    /// unlocks the cursor from the game screen
    /// </summary>
    private void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    /// <summary>
    /// Sets cursor to locked or none state based upon user input 
    /// </summary>
    private void ToggleCursorMode()
    {
        // TODO: refactor to new input system 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LockCursor();
        }
        else if (Input.GetKeyDown(KeyCode.Mouse1) && Cursor.lockState != CursorLockMode.Locked)
        {
            UnlockCursor();
        }
    }

    /// <summary>
    /// Resets the Rotation of the camera to zero
    /// </summary>
    public void LerpCameraRotationToZero(float factor)
    {
        cam.transform.localRotation = Quaternion.Lerp(cam.transform.localRotation, Quaternion.Euler(Vector3.zero), factor);
    }

}
