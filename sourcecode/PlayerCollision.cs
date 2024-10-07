using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameObject gameOverPanel; // Reference to the Game Over UI panel

    private void Start()
    {
        // Ensure the Game Over panel is inactive at the start
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collider has the tag "Spike"
        if (collision.gameObject.CompareTag("Spike"))
        {
            GameOver(); // Call the GameOver function if the player hits a spike
        }
    }

    void GameOver()
    {
        Debug.Log("Game Over!"); // Log message to the console for debugging
        GameManager.Instance.isGameOver = true; // Set game over state in GameManager
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true); // Show the Game Over UI
        }
        
        // Optional: Stop the game or pause the game time
        // Time.timeScale = 0; // Uncomment to pause the game
    }
}
