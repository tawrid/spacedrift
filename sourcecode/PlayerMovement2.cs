using UnityEngine;

public class ConstantSpeedMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of the ball
    public Vector3 direction = Vector3.forward; // Direction of movement

    private void Start()
    {
        // Ensure the direction is normalized
        direction.Normalize();
    }

    private void Update()
    {
        // Check if the game is over before moving
        if (!GameManager.Instance.isGameOver)
        {
            // Move the ball in the specified direction at a constant speed
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }
}
