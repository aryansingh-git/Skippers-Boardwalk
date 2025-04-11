using UnityEngine;

public class OnTriggerEnterScript : MonoBehaviour
{
    public GameObject teleportTarget; // Reference to the empty GameObject

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the colliding object has the tag "Player"
        {
            other.transform.position = teleportTarget.transform.position; // Teleport the player to the target position
        }
    }
}
