using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private string sceneName; // The name of the scene to load
    [SerializeField] private KeyCode inputKey = KeyCode.G; // Default key is "~"

    private bool playerInTrigger = false; // Flag to track if player is in trigger

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = false;
        }
    }

    private void Update()
    {
        // Load scene when input key is pressed and player is in trigger
        if (Input.GetKeyDown(inputKey) && playerInTrigger)
        {
            LoadScene();
        }
    }

    private void LoadScene()
    {
        // Check if the scene is already loaded
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);
            if (scene.name == sceneName)
            {
                // Scene is already loaded, so return
                return;
            }
        }

        // If we reach here, it means the scene is not loaded, so we load it
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
    }

}
