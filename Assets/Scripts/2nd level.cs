using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TicketCheck : MonoBehaviour
{
    public ScoreManager scoreManager; // Reference to the ScoreManager script
    public GameObject invisibleWall; // Reference to the invisible wall
    public GameObject uiElement;

    private void Start()
    {
        uiElement.SetActive(false); // Disable the UI at the start
    }
    void Update()
    {
        // Check if the player has collected more than 50 tickets
        if (scoreManager.tickets >= 50)
        {
            uiElement.SetActive(true); // Toggle the UI element on/off
            // Disable the invisible wall
            invisibleWall.SetActive(false);
        }
    }
}
