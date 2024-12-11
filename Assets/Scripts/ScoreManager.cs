using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance; // Singleton instance for easy access

    public TextMeshProUGUI scoreText; // Assign the UI Text element in the Inspector
    private int score = 0; // Initial score

    void Awake()
    {
        // Ensure there's only one instance of ScoreManager
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateScoreUI();
    }

    // Method to increment the score
    public void AddScore(int value)
    {
        score += value;
        UpdateScoreUI();
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

    // Method to get the current score
    public int GetScore()
    {
        return score;
    }
}
