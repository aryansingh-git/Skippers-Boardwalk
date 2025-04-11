using UnityEngine;

public class OnTriggerAudio : MonoBehaviour
{
    public AudioClip audioClip; // The audio clip to play
    private AudioSource audioSource; // The AudioSource component
    private bool hasPlayed = false; // Add this line

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
        if (other.gameObject.tag == "Player" && !hasPlayed) // Add the check here
        {
            // Play the audio clip
            audioSource.PlayOneShot(audioClip);
            hasPlayed = true; // Set the flag to true

            // Call the DeleteObject method after 19 seconds
            Invoke("DeleteObject", 96f);
        }
    }

    // This method deletes the specified GameObject
    void DeleteObject()
    {
        // Delete the GameObject
        Destroy(gameObject);
    }
}
