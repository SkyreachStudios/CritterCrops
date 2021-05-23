
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform;
    public Vector3 offset;
    bool following;

    [Range(2,10)]
    public float smoothFactor;

    private void Start()
    {
        following = true;
    }
    private void FixedUpdate()
    {
        Follow();
    }

    void Follow()
    {
        if(following == true)
        {
            Vector3 targetPosition = playerTransform.position + offset;
            Vector3 smoothPosition = Vector3.Lerp(playerTransform.position, targetPosition, smoothFactor * Time.fixedDeltaTime);

            transform.position = smoothPosition;
        }

    }
}
