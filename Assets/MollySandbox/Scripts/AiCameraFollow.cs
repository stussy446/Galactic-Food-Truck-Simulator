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
    private bool aiLockOnStart = true;

    bool isFollowingPlayer = true;

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

    void Update()
    {
        if (isFollowingPlayer)
        {
            Vector3 facingDirection = playerTransform.position - ((new Vector3(aiCameraBody.position.x, aiCameraBody.position.y, aiCameraBody.position.z)));

            float movementSpeed = rotationSpeed * Time.deltaTime;

            Vector3 newDirection = Vector3.RotateTowards(aiCameraBody.forward, facingDirection, movementSpeed, 0.0f);

            aiCameraBody.transform.rotation = Quaternion.LookRotation(newDirection);
        }
    }
}
