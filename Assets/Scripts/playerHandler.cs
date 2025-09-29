using System;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class playerHandler : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] private float playerSpeed;
    private int points = 0;
    
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;

    void Start()
    {
        int highScore = PlayerPrefs.GetInt("HighScore");
        highScoreText.text = "High Score: " + highScore;
        
        scoreText.text = "Score: 0";
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        rb.MovePosition(rb.position + movement * playerSpeed * Time.fixedDeltaTime);
        
        if (transform.position.y < -0.3f)
        {
            EndGame();
        }
    }
    public void IncreasePoints()
    {
        points++;
        UpdateScoreUI();
    }
    
    private void UpdateScoreUI()
    {
        scoreText.text = "Score: " + points.ToString();
    }
    private void EndGame()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (points > highScore)
        {
            PlayerPrefs.SetInt("HighScore", points);
            PlayerPrefs.Save();
        }

        // Restart scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //Time.timeScale = 0f; // freeze everything
        Debug.Log("Game Over!");
    }
}
