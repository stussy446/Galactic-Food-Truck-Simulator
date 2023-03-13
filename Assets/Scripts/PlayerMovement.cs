using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector2 horizontalInput;

    /// <summary>
    /// Takes in a vector2 value and sets it to the horizontalInput field for use
    /// </summary>
    /// <param name="receivedHorizontalInput">Vector2</param>
    public void ReceiveInput(Vector2 receivedHorizontalInput)
    {
        horizontalInput = receivedHorizontalInput;
    }
}
