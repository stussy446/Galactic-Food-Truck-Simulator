using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovePosition
{
    private float minX = -41f, minZ = -7.25f, maxX = -26.5f, maxZ = 7f, constY = 0.5f;
    public Vector3 position;

    public RandomMovePosition()
    {
        float x = Random.Range(minX, maxX);
        float z = Random.Range(minZ, maxZ);
        position = new Vector3(x, constY, z);
    }
}
