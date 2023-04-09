using System.Collections;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [Header("Player and Camera Configs")]
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] CameraMover cameraMover;
    [SerializeField] GameObject reticle;
    [SerializeField] Transform replicatorTransform;
    [SerializeField] Transform translatorTransform;
    [SerializeField] Transform buttonTransform;


    PlayerControls playerControls;
    PlayerControls.MovementActions movementActions;

    Vector2 horizontalInput;
    Vector2 mouseInput;

    bool isInteracting;

    public bool IsInteracting { get { return isInteracting; } } 

    private void Awake()
    {
        playerControls = new PlayerControls();
        movementActions = playerControls.Movement;
    }


    private void OnEnable()
    {
        playerControls.Enable();

        movementActions.HorizontalMovement.performed += ctx => horizontalInput = ctx.ReadValue<Vector2>();

        movementActions.MouseX.performed += ctx => mouseInput.x = ctx.ReadValue<float>();
        movementActions.MouseY.performed += ctx => mouseInput.y = ctx.ReadValue<float>();

        movementActions.Interact.performed += ctx => isInteracting = true;
        movementActions.Interact.canceled += ctx => isInteracting = false;   
    }

    private void Update()
    {
        // passes the input value to the PlayerMovement script and CameraMover script each frame
        playerMovement.ReceiveInput(horizontalInput); 
        cameraMover.ReceiveInput(mouseInput, isInteracting);
    }

    private void OnDisable()
    {
        playerControls.Disable();

    }

    /// <summary>
    /// moves player to appropriate position when interacting with the Replicator 
    /// </summary>
    public void GoToReplicatingPosition()
    {
        StartCoroutine(GoToPosition(transform.position, replicatorTransform.position, transform.forward, replicatorTransform.forward));
    }

    /// <summary>
    /// moves player to appropriate position when interacting with the Translator 
    /// </summary>
    public void GoToTranslatorPosition()
    {
        StartCoroutine(GoToPosition(transform.position, translatorTransform.position, transform.forward, translatorTransform.forward));
    }

    /// <summary>
    /// moves player to appropriate position when interacting with the Save The Universe Button
    /// </summary>
    public void GoToButtonPosition()
    {
        StartCoroutine(GoToPosition(transform.position, buttonTransform.position, transform.forward, buttonTransform.forward));
    }

    /// <summary>
    /// Moves object from a starting position and rotation to an ending position and rotation using Lerp
    /// </summary>
    /// <param name="startPos">Vector3 starting position of object</param>
    /// <param name="endPos">Vector3 ending position of object</param>
    /// <param name="startForward">Vector3 starting forward rotation of object</param>
    /// <param name="endForward">Vector3 ending forward rotation of object</param>
    /// <returns>IEnumerator</returns>
    private IEnumerator GoToPosition(Vector3 startPos, Vector3 endPos, Vector3 startForward, Vector3 endForward)
    {
        float difference = 0;
        while (difference < 1)
        {
            transform.position = Vector3.Lerp(startPos, endPos, difference);
            transform.forward = Vector3.Lerp(startForward, endForward, difference);
            cameraMover.LerpCameraRotationToZero(difference);
            difference += Time.deltaTime * 2;
            yield return null;
        }
        transform.position = endPos;
        transform.forward = endForward;

    }

    /// <summary>
    /// Disables camera and player movement for the player while interacting with UI in the world
    /// </summary>
    public void DisableMovement(bool pauseCamera)
    {
        playerMovement.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        reticle.SetActive(false);
        cameraMover.IsPaused = pauseCamera;
        this.enabled = false;
    }

    /// <summary>
    /// Reenables camera and player movement after done interacting with UI in the world
    /// </summary>
    public void EnableMovement()
    {
        playerMovement.enabled = true;
        this.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        cameraMover.IsPaused = false;
        reticle.SetActive(true);
    }
}
