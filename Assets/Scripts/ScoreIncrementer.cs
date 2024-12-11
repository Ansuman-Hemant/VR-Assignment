using UnityEngine;
using TMPro;

public class ScoreIncrementer : MonoBehaviour
{
    public static ScoreIncrementer Instance; // Singleton instance for easy access

    public TextMeshProUGUI scoreText; // Assign the UI Text element in the Inspector
    private int score = 0; // Initial score

    void Awake()
    {
        // Ensure there's only one instance of ScoreIncrementer
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
    }

    void Start()
    {
        UpdateScoreUI(); // Initialize the UI with the starting score
    }

    // Method to increment the score
    public void AddScore(int value)
    {
        score += value; // Increment the score by the specified value
        UpdateScoreUI(); // Update the UI to reflect the new score
    }

    // Update the score display
    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = $"Score: {score}";
        }
        else
        {
            Debug.LogWarning("Score Text is not assigned!");
        }
    }

    // Optional: Method to retrieve the current score
    public int GetScore()
    {
        return score;
    }

    public void ResetScore()
    {
        score = 0; // Reset the score to 0
        UpdateScoreUI(); // Update the UI to reflect the reset score
    }

}
