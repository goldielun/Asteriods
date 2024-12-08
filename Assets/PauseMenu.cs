using UnityEngine;
using UnityEngine.SceneManagement;
public class yauseMenu : MonoBehaviour
{
    [SerializeField] GameObject PauseMenu; // Reference to the PauseMenu GameObject
    private bool isPaused = false; // Track the pause state

    void Update()
    {
        // Check if the "P" key is pressed
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0; // Pause the game
        PauseMenu.SetActive(true); // Activate the target object
        isPaused = true; // Set pause state to true
    }
    private void ResumeGame()
    {
        Time.timeScale = 1; // Resume the game
        PauseMenu.SetActive(false); // Deactivate the target object
        isPaused = false; // Set pause state to false
    }
}
