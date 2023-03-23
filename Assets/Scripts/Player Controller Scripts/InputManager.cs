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

        ActionList.OnEnteredFoodReplicator += ctx => GoToReplicatingPosition();
        ActionList.OnEnteredTranslator += ctx => GoToTranslatorPosition();
        ActionList.OnEnteredButtonPressing += ctx => GoToButtonPosition();
    }

    private void Update()
    {
        // passes the input value to the PlayerMovement script and CameraMover script each frame
        playerMovement.ReceiveInput(horizontalInput); 
        cameraMover.ReceiveInput(mouseInput);
    }

    private void OnDisable()
    {
        playerControls.Disable();
        ActionList.OnEnteredFoodReplicator -= ctx => GoToReplicatingPosition();
        ActionList.OnEnteredTranslator -= ctx => GoToTranslatorPosition();
        ActionList.OnEnteredButtonPressing -= ctx => GoToButtonPosition();

    }

    public void GoToReplicatingPosition()
    {
        StartCoroutine(GoToPosition(transform.position, replicatorTransform.position, transform.forward, replicatorTransform.forward));
    }

    public void GoToTranslatorPosition()
    {
        StartCoroutine(GoToPosition(transform.position, translatorTransform.position, transform.forward, translatorTransform.forward));
    }

    public void GoToButtonPosition()
    {
        StartCoroutine(GoToPosition(transform.position, buttonTransform.position, transform.forward, buttonTransform.forward));
    }

    private IEnumerator GoToPosition(Vector3 startPos, Vector3 endPos, Vector3 startForward, Vector3 endForward)
    {
        float difference = 0;
        while (difference < 1)
        {
            transform.position = Vector3.Lerp(startPos, endPos, difference);
            transform.forward = Vector3.Lerp(startForward, endForward, difference);
            difference += Time.deltaTime * 2;
            yield return null;
        }
        transform.position = endPos;
        transform.forward = endForward;
    }

    public void DisableMovement()
    {
        playerMovement.enabled = false;

        Cursor.lockState = CursorLockMode.None;
        reticle.SetActive(false);

        this.enabled = false;
    }

    public void EnableMovement()
    {
        playerMovement.enabled = true;
        this.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        reticle.SetActive(true);
    }
}
