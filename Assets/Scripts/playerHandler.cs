using System;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class playerHandler : MonoBehaviour
{
    // Rigidbody reference used for physics-based movement
    private Rigidbody rb;

    // Speed multiplier for player movement
    [SerializeField] private float playerSpeed;
    
    // Current score (coins collected this run)
    private int points = 0;
    
    // UI text for current score
    [SerializeField] private TextMeshProUGUI scoreText;
    // UI text for persistent high score
    [SerializeField] private TextMeshProUGUI highScoreText;

    void Start()
    {
        // Load saved high score from PlayerPrefs (defaults to 0 if none exists)
        int highScore = PlayerPrefs.GetInt("HighScore");
        
        // Update the UI to show the stored high score
        highScoreText.text = "High Score: " + highScore;
        
        // Reset current score UI at game start
        scoreText.text = "Score: 0";
    }

    private void Awake()
    {
        // Cache reference to the Rigidbody for movement
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // Read player input (WASD / Arrow Keys) for horizontal and vertical axes
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        
        // Apply movement to Rigidbody in a physics-safe way
        rb.MovePosition(rb.position + movement * playerSpeed * Time.fixedDeltaTime);
        
        // Check if player has fallen below the floor (game over condition)
        if (transform.position.y < -0.3f)
        {
            EndGame();
        }
    }
    
    // Called when player collects a coin
    public void IncreasePoints()
    {
        points++;   // increase score by 1
        UpdateScoreUI();    // update UI display
    }
    
    // Update the score text on screen
    private void UpdateScoreUI()
    {
        scoreText.text = "Score: " + points.ToString();
    }
    
    // Handles game over logic (falling off map or touching laser)
    private void EndGame()
    {
        // Load previously saved high score
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        
        // If current score beats it, update the stored high score
        if (points > highScore)
        {
            PlayerPrefs.SetInt("HighScore", points);
            PlayerPrefs.Save();
        }

        // Restart the current scene to reset the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
        //Time.timeScale = 0f; // Optional: could use Time.timeScale = 0f to pause instead of restart
        Debug.Log("Game Over!");
    }
}
