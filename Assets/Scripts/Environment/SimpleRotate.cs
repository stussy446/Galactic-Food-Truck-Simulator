using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRotate: MonoBehaviour
{

    [SerializeField]
    private Vector3 rotation;

    [SerializeField]
    private float rotateSpeed;
    void Update()
    {
        transform.Rotate(rotation * rotateSpeed * Time.deltaTime);
    }
}
