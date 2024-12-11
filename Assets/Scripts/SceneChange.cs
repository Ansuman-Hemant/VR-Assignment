using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneButton : MonoBehaviour
{
    // Name of the scene to load
    public string sceneName;

    // Method to be called when the button is clicked
    public void LoadScene()
    {
        // Load the specified scene
        SceneManager.LoadScene(sceneName);
    }
}
