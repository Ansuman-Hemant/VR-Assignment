using UnityEngine;

public class EnableBubblesOnButtonClick : MonoBehaviour
{
    public GameObject bubblesParent; // The parent GameObject containing all the bubble GameObjects

    public void EnableBubbles()
    {
        if (bubblesParent != null)
        {
            // Loop through all child GameObjects under the parent
            foreach (Transform bubble in bubblesParent.transform)
            {
                bubble.gameObject.SetActive(true); // Enable each bubble
            }
        }
        else
        {
            Debug.LogWarning("Bubbles parent GameObject is not assigned.");
        }

        // Reset the score to 0
        if (ScoreIncrementer.Instance != null)
        {
            ScoreIncrementer.Instance.ResetScore();
        }
        else
        {
            Debug.LogWarning("ScoreIncrementer instance is not found.");
        }
    }
}