using UnityEngine;

public class InputManager : MonoBehaviour
{
    [Header("Player and Camera Configs")]
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] CameraMover cameraMover;
    [SerializeField] GameObject reticle;

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

        ActionList.OnEnteredFoodReplicator += ctx => DisableMovement();
        ActionList.OnDoneReplicatingFood += ctx => EnableMovement();
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
        
        ActionList.OnEnteredFoodReplicator -= ctx => DisableMovement();
        ActionList.OnDoneReplicatingFood -= ctx => EnableMovement();
    }

    public void DisableMovement()
    {
        this.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        reticle.SetActive(false);
        StateManager.instance.SwitchStates(new FulfillingOrderState());
    }

    public void EnableMovement()
    {
        this.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        reticle.SetActive(true);
        StateManager.instance.SwitchStates(new FreeRoamingState());
    }
}
