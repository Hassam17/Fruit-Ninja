using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private AudioClip buttonClickSound; // Add this line for the button sound
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            // If the AudioSource component does not exist, add one
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    // This method will be called when the "New Game" button is clicked
    public void StartNewGame()
    {
        PlaySound();
        SceneManager.LoadScene(1);
    }

    // This method will be called when the "Exit" button is clicked
    public void ExitGame()
    {
        PlaySound();
        print("EXIT");
        Application.Quit();

        // Uncomment the following line if you want to stop play mode in the Unity Editor
        // UnityEditor.EditorApplication.isPlaying = false;
    }

    private void PlaySound()
    {
        if (buttonClickSound != null)
        {
            audioSource.PlayOneShot(buttonClickSound);
        }
    }
}
