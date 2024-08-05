using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // This method will be called when the "New Game" button is clicked
    public void StartNewGame()
    {
        // Replace "GameScene" with the name of your game scene
        SceneManager.LoadScene(1);
    }

    // This method will be called when the "Exit" button is clicked
    public void ExitGame()
    {
        print("EXIT");
        // This will only work in a built application
        Application.Quit();

        // If you are testing in the Unity Editor, this line can be used
        // to stop the play mode, but it will not work in a build.
        // UnityEditor.EditorApplication.isPlaying = false;
    }
}
