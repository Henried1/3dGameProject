using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Assign your fish GameObject to this field
    public float smoothSpeed = 0.125f; // Adjust the smoothness of the camera follow

    void LateUpdate()
    {
        if (target != null)
        {
            // Calculate the desired position and rotation
            Vector3 desiredPosition = target.position;
            Quaternion desiredRotation = target.rotation;

            // Smoothly interpolate the current position and rotation towards the desired ones
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, smoothSpeed);
        }
    }
}
