using UnityEngine;

public class Key : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log("Key picked up");
        PlayerHasKey.Instance.HasKey = true; // Set the HasKey property to true when the player interacts with the key
        Destroy(gameObject); // Destroy the key object after it has been picked up
    }
}