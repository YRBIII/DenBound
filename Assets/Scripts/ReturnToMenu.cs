using UnityEngine;
using UnityEngine.SceneManagement;

// Handles returning the player to the main menu scene
public class ReturnToMenu : MonoBehaviour
{
    // Loads the main menu scene
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}