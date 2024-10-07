using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } // Singleton instance

    public bool isGameOver = false; // Flag to track if the game is over

    private void Awake()
    {
        // Implement Singleton pattern to ensure only one instance exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep this object alive across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        // Check for restart input
        if (isGameOver && Input.GetKeyDown(KeyCode.R)) // Press R to restart
        {
            RestartGame();
        }
    }

    public void RestartGame()
    {
        // Reset game state
        isGameOver = false; // Reset game over state

        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
