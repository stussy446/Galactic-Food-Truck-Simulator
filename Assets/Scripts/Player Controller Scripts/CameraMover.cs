using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [Header("Mouse Sensitivity")]
    [SerializeField] float sensitivityX = 8f;
    [SerializeField] float sensitivityY = 8f;

    [Header("Camera and Camera Configs")]
    [SerializeField] Transform playerCamera;
    [SerializeField] float xClamp = 85f;
    [SerializeField] float detectionRange = 1000f;
    [SerializeField] LayerMask interactableLayer;
    float xRotation = 0f;

    float mouseX;
    float mouseY;
    Camera cam;
    InputManager inputManager;

    private void Awake()
    {
        RemoveExtraCameras();
        cam = Camera.main;
        LockCursor();

        inputManager = GetComponent<InputManager>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    /// <summary>
    /// Removes default main camera from scene to ensure the players fps camera is the one used
    /// </summary>
    private void RemoveExtraCameras()
    {
        Camera[] cameras = FindObjectsOfType<Camera>();
        foreach (Camera camera in cameras)
        {
            if (camera.GetComponentInParent<PlayerMovement>() == null)
            {
                Destroy(camera.gameObject);
            }
        }
    }

    private void Update()
    {
        RotateHorizontally();
        RotateVertically();
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
            if (Input.GetMouseButtonDown(0))
            {
                // TODO: This can be changed to pull from different menu types, that way we can for example, start with 2 item, then 4 and then go to 8
                MenuManager.Instance.ActivateMenu(MenuType.EightItem);

                // TODO: Enter replication state here, code below is to confirm functionality and should likely be refactored to state machine later 
                inputManager.DisableMovement();
                UnlockCursor();
            }
        }
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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UnlockCursor();
        }
        else if (Input.GetKeyDown(KeyCode.Mouse1) && Cursor.lockState != CursorLockMode.Locked)
        {
            LockCursor();
        }
    }
}
