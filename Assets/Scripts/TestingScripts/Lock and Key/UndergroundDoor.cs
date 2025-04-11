using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UndergroundDoor : MonoBehaviour, IInteractable
{
    public GameObject objectToDisable; // The object to disable when the lock is unlocke   
    public Image noKeyImage; // The UI image to display when the player doesn't have a key

    private void Start()
    {
        noKeyImage.gameObject.SetActive(false); // Disable the no key image at the start
    }

    public void Interact()
    {
        if (PlayerHasBiggerKey.Instance.HasBiggerKey)
        {
            Debug.Log("Lock unlocked");
            objectToDisable.SetActive(false); // Disable the specified game object
        }
        else
        {
            StartCoroutine(ShowNoKeyImage());
        }
    }

    private IEnumerator ShowNoKeyImage()
    {
        noKeyImage.gameObject.SetActive(true); // Show the no key image
        yield return new WaitForSeconds(3); // Wait for 3 seconds
        noKeyImage.gameObject.SetActive(false); // Hide the no key image
    }
}
