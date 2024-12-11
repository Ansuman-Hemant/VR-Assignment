using UnityEngine;
using TMPro;

public class ScoreBasedPanelSwitcher : MonoBehaviour
{
    public GameObject currentPanel; // Assign the current UI panel in the Inspector
    public GameObject nextPanel; // Assign the next UI panel in the Inspector
    public int targetScore = 3; // The score required to switch panels

    private bool hasSwitched = false; // Ensure the panel switch happens only once

    void Update()
    {
        // Check if the target score has been reached and the panels haven't switched yet
        if (!hasSwitched && ScoreManager.Instance != null && ScoreManager.Instance.GetScore() >= targetScore)
        {
            SwitchPanel();
        }
    }

    void SwitchPanel()
    {
        hasSwitched = true; // Prevent multiple switches

        Debug.Log("Target score reached! Switching panels.");

        // Deactivate the current panel
        if (currentPanel != null)
        {
            currentPanel.SetActive(false);
        }

        // Activate the next panel
        if (nextPanel != null)
        {
            nextPanel.SetActive(true);

            // Check if the next panel has a timer and start it
            ReverseTimer nextPanelTimer = nextPanel.GetComponentInChildren<ReverseTimer>();
            if (nextPanelTimer != null)
            {
                nextPanelTimer.StartTimer();
            }
            else
            {
                Debug.LogWarning("No ReverseTimer component found on the next panel.");
            }
        }
    }
}