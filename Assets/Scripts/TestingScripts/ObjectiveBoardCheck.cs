using UnityEngine;
using UnityEngine.UI;

public class ObjectiveBoardCheck : MonoBehaviour
{
    public GameObject uiElement; // Assign your UI element in the inspector

    private bool isPlayerInTrigger = false;

    private void Start()
    {
        uiElement.SetActive(false); // Disable the UI at the start
    }

    private void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.G))
        {
            uiElement.SetActive(true); // Toggle the UI element on/off
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
        }
    }
}
