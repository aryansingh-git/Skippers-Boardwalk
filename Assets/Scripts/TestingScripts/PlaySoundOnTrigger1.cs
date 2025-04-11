using UnityEngine;

public class PlaySoundOnTriggerDuck : MonoBehaviour
{
    AudioSource audioSource;

    void Start()
    {
        // Get the AudioSource component attached to this game object
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the other object has the "BasketBall" tag
        if (other.gameObject.CompareTag("Ball"))
        {
            // Play the sound
            audioSource.Play();
        }
    }
}
