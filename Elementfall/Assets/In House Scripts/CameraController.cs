using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform followTarget, lookTarget;
    public float followSpeed = 10f;
    public float rotationSpeed = 5f;
    public float minVerticalAngle = -30f; // Look down limit
    public float maxVerticalAngle = 60f;  // Look up limit

    private float verticalRotation = 0f;
    private float horizontalRotation = 0f;

    void LateUpdate()
    {
        Vector3 targetPosition = followTarget.position;
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

        transform.LookAt(lookTarget);
    }

    public void Rotate(Vector2 input)
    {
        // Horizontal rotation (left/right)
        horizontalRotation += input.x * rotationSpeed;
        
        // Vertical rotation (up/down)
        verticalRotation -= input.y * rotationSpeed; // Negative because up on mouse/stick should look up
        verticalRotation = Mathf.Clamp(verticalRotation, minVerticalAngle, maxVerticalAngle);

        // Apply rotation to camera
        Quaternion rotation = Quaternion.Euler(verticalRotation, horizontalRotation, 0);
        transform.rotation = rotation;

        // Position camera at an offset from the target
        Vector3 offset = rotation * new Vector3(0, 0, -5f); // -5 units back from target
        transform.position = followTarget.position + offset;
    }
}