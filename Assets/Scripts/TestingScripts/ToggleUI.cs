using UnityEngine;

public class ToggleUI : MonoBehaviour
{
    public GameObject uiElement; // Assign your UI element in the inspector

    private void Start()
    {
        uiElement.SetActive(false); // Disable the UI at the start
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            uiElement.SetActive(!uiElement.activeSelf); // Toggle the UI element on/off
        }
    }
}
