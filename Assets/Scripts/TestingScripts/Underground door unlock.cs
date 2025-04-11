using UnityEngine;
using UnityEngine.UI;

public class TriggerScript : MonoBehaviour
{
    public AudioClip audioClip; // The audio clip to play
    public GameObject objectToDelete; // The GameObject to delete
    public GameObject objectiveboard; // The GameObject to delete
    private AudioSource audioSource; // The AudioSource component

    // Start is called before the first frame update
    void Start()
    {
        // Get the AudioSource component
        audioSource = GetComponent<AudioSource>();
    }

    // This method is called when the Player enters the trigger
    void OnTriggerEnter(Collider other)
    {
        // Check if the GameObject that entered the trigger is the Player
        if (other.gameObject.tag == "Player")
        {
            // Play the audio clip
            audioSource.PlayOneShot(audioClip);
            Destroy(objectiveboard);

            // Call the DeleteObject method after 19 seconds
            Invoke("DeleteObject", 19f);

        }
    }

    // This method deletes the specified GameObject
    void DeleteObject()
    {
        // Delete the GameObject
        Destroy(objectToDelete);
        Destroy(gameObject);
    }
}
