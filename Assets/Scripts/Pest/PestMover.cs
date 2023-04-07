using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PestMover : MonoBehaviour
{
    private Vector3 moveToPos;
    private float bugSpeed = 6;

    // Start is called before the first frame update
    void OnEnable()
    {
        RandomMovePosition randomPos = new RandomMovePosition();
        moveToPos = randomPos.position;
    }

    // Update is called once per frame
    void Update()
    {
        MoveToPosition(moveToPos);
        if (transform.position == moveToPos)
        {
            moveToPos = new RandomMovePosition().position;
        }
    }

    private void MoveToPosition(Vector3 position)
    {
        transform.position = Vector3.MoveTowards(transform.position, position, bugSpeed * Time.deltaTime);
    }
}
