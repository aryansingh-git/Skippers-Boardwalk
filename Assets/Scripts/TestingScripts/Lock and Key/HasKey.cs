using UnityEngine;

public class PlayerHasKey : MonoBehaviour
{
    public static PlayerHasKey Instance { get; private set; } // Singleton instance
    public bool HasKey { get; set; } // Property to check if the player has a key

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}