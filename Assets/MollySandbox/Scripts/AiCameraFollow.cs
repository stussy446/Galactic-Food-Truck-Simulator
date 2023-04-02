using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiCameraFollow : MonoBehaviour
{

    [SerializeField]
    private Transform playerTransform;

    [SerializeField]
    private Transform aiCameraBody;

    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    private float lookOffset = 2f;

    [SerializeField]
    private bool aiLockOnStart = true;

    bool isFollowingPlayer = true;

    // Start is called before the first frame update
    void Start()
    {
        if (transform.Find("Player"))
        {
            playerTransform = transform.Find("Player");
        }

        if (aiLockOnStart)
        {
            aiCameraBody.transform.LookAt(playerTransform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isFollowingPlayer)
        {
            Vector3 facingDirection = playerTransform.position - ((new Vector3(aiCameraBody.position.x + lookOffset, aiCameraBody.position.y + lookOffset, aiCameraBody.position.z + lookOffset)));

            float movementSpeed = rotationSpeed * Time.deltaTime;

            Vector3 newDirection = Vector3.RotateTowards(aiCameraBody.forward, facingDirection, movementSpeed, 0.0f);

            aiCameraBody.transform.rotation = Quaternion.LookRotation(newDirection);
        }
    }
}
