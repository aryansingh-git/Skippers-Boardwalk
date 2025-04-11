using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UnloadSceneOnClick : MonoBehaviour
{
    public string Safe; // Name of the scene to unload

    void Start()
    {
        // Get the Button component on the game object and set up the click event
        GetComponent<Button>().onClick.AddListener(UnloadScene);
    }

    void UnloadScene()
    {
        // Unload the specified scene asynchronously
        Cursor.visible = false; // Enable the cursor
        Cursor.lockState = CursorLockMode.Locked; // Allow the cursor to move
        SceneManager.UnloadSceneAsync(Safe);
    }
}
