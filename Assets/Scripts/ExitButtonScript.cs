using UnityEngine;
using UnityEngine.UI;

public class ExitButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Get the Button component and add a listener to the onClick event
        GetComponent<Button>().onClick.AddListener(ExitGame);
    }

    // Method to exit the game
    void ExitGame()
    {
        // If we are running in a standalone build of the game
#if UNITY_STANDALONE
        // Quit the application
        Application.Quit();
#endif

        // If we are running in the editor
#if UNITY_EDITOR
        // Stop playing the scene
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
