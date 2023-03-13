using UnityEngine;

public class InputManager : MonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField] PlayerMovement playerMovement;

    PlayerControls playerControls;
    PlayerControls.MovementActions movementActions;

    Vector2 horizontalInput;

    private void Awake()
    {
        playerControls = new PlayerControls();
        movementActions = playerControls.Movement;
    }


    private void OnEnable()
    {
        playerControls.Enable();
        movementActions.HorizontalMovement.performed += ctx => horizontalInput = ctx.ReadValue<Vector2>();
    }

    private void Update()
    {
        // passes the input value to the PlayerMovement script for each frame
        playerMovement.ReceiveInput(horizontalInput);    
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }
}
