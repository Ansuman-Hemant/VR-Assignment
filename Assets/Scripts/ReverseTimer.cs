using UnityEngine;
using TMPro;

public class ReverseTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Assign this in the Inspector
    public int startTime = 5; // Set the starting time (in seconds)

    private float currentTime; // Tracks the remaining time
    private bool isTimerRunning = false; // Ensures the timer doesn't start multiple times

    public GameObject currentPanel; // Assign the current UI panel in the Inspector
    public GameObject nextPanel; // Assign the next UI panel in the Inspector

    void Update()
    {
        // Only update the timer if it's running
        if (isTimerRunning && currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            UpdateTimerUI();
        }
        else if (isTimerRunning && currentTime <= 0)
        {
            currentTime = 0; // Ensure it doesn't go below zero
            isTimerRunning = false; // Stop the timer
            TimerEnded();
        }
    }

    public void StartTimer()
    {
        // Start the timer only if it's not already running
        if (!isTimerRunning)
        {
            currentTime = startTime; // Reset the timer
            isTimerRunning = true;  // Mark the timer as running
            UpdateTimerUI(); // Immediately update the displayed time
        }
    }

    void UpdateTimerUI()
    {
        // Update the displayed timer text
        timerText.text = Mathf.Ceil(currentTime).ToString(); // Round up to the nearest whole number
    }

    void TimerEnded()
    {
        // Actions when the timer ends
        Debug.Log("Timer Ended!");

        // Switch to the next UI panel and start the timer for the next panel
        if (currentPanel != null)
        {
            currentPanel.SetActive(false); // Deactivate the current panel
        }

        if (nextPanel != null)
        {
            nextPanel.SetActive(true); // Activate the next panel

            // Ensure the timer starts on the next panel
            ReverseTimer nextPanelTimer = nextPanel.GetComponentInChildren<ReverseTimer>();
            if (nextPanelTimer != null)
            {
                Debug.Log("Starting timer on the next panel.");
                nextPanelTimer.StartTimer();
            }
            else
            {
                Debug.LogWarning("No ReverseTimer component found on the next panel.");
            }
        }
    }
}
