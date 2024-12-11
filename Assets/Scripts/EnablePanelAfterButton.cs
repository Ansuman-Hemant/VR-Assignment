using UnityEngine;
using UnityEngine.UI;

public class EnablePanelAfterButtons : MonoBehaviour
{
    public GameObject panelToEnable; // The UI panel to enable
    public GameObject[] buttons; // Array to hold the three buttons

    private bool[] buttonClicked; // Tracks the state of each button

    void Start()
    {
        // Initialize buttonClicked array
        buttonClicked = new bool[buttons.Length];

        // Register listeners for active buttons
        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttons[i] != null && buttons[i].activeSelf)
            {
                int index = i;
                Button buttonComponent = buttons[i].GetComponent<Button>();
                if (buttonComponent != null)
                {
                    buttonComponent.onClick.AddListener(() => OnButtonClicked(index));
                }
                else
                {
                    Debug.LogError($"GameObject at index {i} does not have a Button component!");
                }
            }
        }

        // Ensure the panel is initially disabled
        if (panelToEnable != null)
        {
            panelToEnable.SetActive(false);
        }
        else
        {
            Debug.LogError("Panel to enable is not assigned!");
        }
    }

    void OnButtonClicked(int index)
    {
        Debug.Log($"Button {index} clicked");
        buttonClicked[index] = true;

        if (AllButtonsClicked())
        {
            EnablePanel();
        }
    }

    bool AllButtonsClicked()
    {
        foreach (bool clicked in buttonClicked)
        {
            if (!clicked) return false;
        }
        Debug.Log("All buttons have been clicked!");
        return true;
    }

    void EnablePanel()
    {
        if (panelToEnable != null)
        {
            panelToEnable.SetActive(true);
            Debug.Log("Panel enabled.");
        }
        else
        {
            Debug.LogError("Panel to enable is not assigned!");
        }
    }
}
