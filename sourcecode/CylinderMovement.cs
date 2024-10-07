using UnityEngine;

public class CylinderMovement : MonoBehaviour
{
    public float moveSpeed = 2f; // Speed of the cylinder's movement
    public float verticalLimit = 5f; // Limit for vertical movement

    private void Update()
    {
        // Check if GameManager instance exists
        if (GameManager.Instance == null)
        {
            Debug.LogError("GameManager instance is null! Make sure the GameManager is in the scene.");
            return; // Exit early if GameManager is not found
        }

        // Check if the game is over
        if (GameManager.Instance.isGameOver)
        {
            return; // Stop updating if the game is over
        }

        // Get vertical input (W/S or Up/Down Arrow keys)
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the new position
        Vector3 newPosition = transform.position + new Vector3(0, verticalInput * moveSpeed * Time.deltaTime, 0);

        // Clamp the Y position to stay within limits
        newPosition.y = Mathf.Clamp(newPosition.y, -verticalLimit, verticalLimit);

        // Update the cylinder's position
        transform.position = newPosition;
    }
}
