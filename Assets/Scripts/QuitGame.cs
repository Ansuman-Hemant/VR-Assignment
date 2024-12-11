using UnityEngine;

public class QuitGameButton : MonoBehaviour
{
    // Method to quit the game
    public void QuitGame()
    {
        Debug.Log("Quitting the game...");

        // Quit the application
        Application.Quit();

        // This line is for testing in the Unity Editor
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
