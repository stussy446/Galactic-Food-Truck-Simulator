using UnityEngine;

/// <summary>
/// Controls the movement of the instance of the bug in the scene
/// </summary>
public class PestMover : MonoBehaviour
{
    // Position bug will aim at
    private Vector3 moveToPos;

    // Move speed
    private float bugSpeed = 6;

    // Find new random position
    private void OnEnable()
    {
        moveToPos = new RandomMovePosition().position;
    }

    private void Update()
    {
        if (GameManager.instance.gamePaused == true)
            return;

        // Go to random position
        MoveToPosition(moveToPos);

        // If bug has arrived, choose new random position
        if (transform.position == moveToPos)
        {
            moveToPos = new RandomMovePosition().position;
        }
    }

    /// <summary>
    /// Moves bug to a specified position
    /// </summary>
    /// <param name="position">Position where bug should end up</param>
    private void MoveToPosition(Vector3 position)
    {
        transform.LookAt(position);
        transform.position = Vector3.MoveTowards(transform.position, position, bugSpeed * Time.deltaTime);
    }
}
