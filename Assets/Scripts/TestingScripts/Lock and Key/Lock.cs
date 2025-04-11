using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Lock : MonoBehaviour, IInteractable
{
    public GameObject objectToDisable; // The object to disable when the lock is unlocked
    public GameObject particleEffectPrefab;
    public Image noKeyImage; // The UI image to display when the player doesn't have a key
    public GameObject Obj;

    private void Start()
    {
        noKeyImage.gameObject.SetActive(false); // Disable the no key image at the start
        Obj.SetActive(false); // Disable the UI at the start
    }

    public void Interact()
    {
        if (PlayerHasKey.Instance.HasKey)
        {
            Debug.Log("Lock unlocked");
            objectToDisable.SetActive(false); // Disable the specified game object
            GameObject particleEffect = Instantiate(particleEffectPrefab, transform.position, Quaternion.identity);  // Instantiate a particle effect
            Destroy(particleEffect, particleEffect.GetComponent<ParticleSystem>().main.duration);
            Obj.SetActive(true);
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
