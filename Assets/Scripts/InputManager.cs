using UnityEngine;

public class InputManager : MonoBehaviour
{
    [Header("Player and Camera Movement")]
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] CameraMover cameraMover;

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
    }

    private void Update()
    {
        // passes the input value to the PlayerMovement script for each frame
        playerMovement.ReceiveInput(horizontalInput); 
        cameraMover.ReceiveInput(mouseInput);
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }
}
