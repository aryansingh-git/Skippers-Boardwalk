using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
{
    public Transform player, destination;
    public GameObject playerg;
    public AudioSource mainMapSound; // The AudioSource component of the main map sound

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerg.SetActive(false);
            mainMapSound.Stop(); // Stop the main map sound
            player.position = destination.position;
            playerg.SetActive(true);
        }
    }
}
