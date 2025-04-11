using UnityEngine;

public class PlaySoundOnTrigger : MonoBehaviour
{
    public AudioClip audioClip;
    public AudioSource audioSource;

    void OnTriggerEnter(Collider other)
    {
        // Check if the other object has the "BasketBall" tag
        if (other.gameObject.CompareTag("BasketBall"))
        {
            audioSource.clip = audioClip;
            audioSource.Play();
        }
    }
}
