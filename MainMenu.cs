using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        Debug.Log("Start Game button clicked!");
        // Load the game scene (make sure it's added in the build settings)
        SceneManager.LoadScene("GameScene");  
    }

    public void ExitGame()
    {
        Debug.Log("Exit Game button clicked!");
        // Quit the application (works in standalone builds)
        Application.Quit();
    }

    private void Update()
    {
        
    }

}
