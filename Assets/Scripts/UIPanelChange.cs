using UnityEngine;
using UnityEngine.UI;

public class OpenAndReplacePanelOnClick : MonoBehaviour
{
    // Reference to the button
    public Button yourButton;

    // Reference to the panel you want to open
    public GameObject panelToOpen;

    // Reference to the panel you want to remove (deactivate)
    public GameObject panelToRemove;

    void Start()
    {
        // Ensure the new panel is initially hidden
        panelToOpen.SetActive(false);

        // Add a listener to the button to call the OpenAndReplacePanel method when clicked
        yourButton.onClick.AddListener(OpenAndReplacePanel);
    }

    void OpenAndReplacePanel()
    {
        // Deactivate the old panel
        panelToRemove.SetActive(false);

        // Show the new panel
        panelToOpen.SetActive(true);
    }
}
