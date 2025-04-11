using UnityEngine;
using UnityEngine.UI;

public class TicketTrigger : MonoBehaviour
{
    public GameObject uiElement;
    public GameObject particleEffectPrefab;

    private void Start()
    {
        uiElement.SetActive(false); // Disable the UI at the start
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) // Replace "Player" with the tag of your player object
        {
            uiElement.SetActive(!uiElement.activeSelf);
            ScoreManager.instance.tickets += 10; // Add 10 tickets

            GameObject particleEffect = Instantiate(particleEffectPrefab, transform.position, Quaternion.identity);  // Instantiate a particle effect
            Destroy(particleEffect, particleEffect.GetComponent<ParticleSystem>().main.duration);
            gameObject.SetActive(false);
        }
    }
}
