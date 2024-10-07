using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    public Transform target;  // The player or object the camera will orbit around
    public float distance = 5f;  // Distance from the target
    public float minDistance = 2f;  // Minimum zoom distance
    public float maxDistance = 10f;  // Maximum zoom distance
    public float rotationSpeed = 100f;  // Speed of rotation around the target
    public float zoomSpeed = 2f;  // Speed of zooming in/out

    private float currentAngle = 180f;  // Set the starting angle to 180 degrees to face the opposite side

    void Update()
    {
        // Get horizontal input (A/D keys or Left/Right Arrows)
        float horizontalInput = Input.GetAxis("Horizontal");

        // Update the angle based on input and invert it to rotate in the correct direction
        currentAngle -= horizontalInput * rotationSpeed * Time.deltaTime;

        // Calculate the new position of the camera based on the current angle
        float posX = target.position.x + distance * Mathf.Sin(currentAngle * Mathf.Deg2Rad);
        float posZ = target.position.z + distance * Mathf.Cos(currentAngle * Mathf.Deg2Rad);

        // Set the camera's position to the new calculated position
        transform.position = new Vector3(posX, transform.position.y, posZ);

        // Make the camera look at the target (player)
        transform.LookAt(target);

        // Zoom in and out based on scroll wheel input
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        // Update the distance within min and max range
        distance -= scrollInput * zoomSpeed;
        distance = Mathf.Clamp(distance, minDistance, maxDistance);  // Keep distance within limits
    }
}
