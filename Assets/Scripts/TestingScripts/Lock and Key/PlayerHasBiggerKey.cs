using UnityEngine;

public class PlayerHasBiggerKey : MonoBehaviour
{
    public static PlayerHasBiggerKey Instance { get; private set; } // Singleton instance
    public bool HasBiggerKey { get; set; } // Property to check if the player has a key

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