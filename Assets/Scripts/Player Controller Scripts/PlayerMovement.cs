using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Configs")]
    [SerializeField] CharacterController characterController;
    [SerializeField] float movementSpeed = 11f;

    Vector2 playerMovement;

    private void Update()
    {
        Move();
    }

    /// <summary>
    /// Takes in a vector2 value and sets it to the horizontalInput field for use
    /// </summary>
    /// <param name="receivedHorizontalInput">Vector2</param>
    public void ReceiveInput(Vector2 receivedHorizontalInput)
    {
        playerMovement = receivedHorizontalInput;
    }

    /// <summary>
    /// Calculates the horizontal velocity to be used for movement using the horizontal input and movement speed 
    /// </summary>
    /// <returns>Vector3 representing the calculated velocity</returns>
    private Vector3 CalculateHorizontalVelocity()
    {
        Vector3 xVelocity = transform.right * playerMovement.x;
        Vector3 yVelocity = transform.forward * playerMovement.y;

        return (xVelocity + yVelocity) * movementSpeed;
    }

    /// <summary>
    /// Moves the player with the character controller based on the calculated horizontal velocity
    /// </summary>
    private void Move()
    {
        Vector3 horizontalVelocity = CalculateHorizontalVelocity();
        characterController.Move(horizontalVelocity * Time.deltaTime);
    }

}