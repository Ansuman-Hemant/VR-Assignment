using UnityEngine;
using UnityEngine.UI;

public class StartTimerOnClick : MonoBehaviour
{
    public Button startButton; // Assign your button in the Inspector
    public ReverseTimer reverseTimer; // Assign the ReverseTimer script in the Inspector

    void Start()
    {
        if (startButton != null)
        {
            startButton.onClick.AddListener(() =>
            {
                if (reverseTimer != null)
                {
                    reverseTimer.StartTimer();
                }
            });
        }
    }
}
