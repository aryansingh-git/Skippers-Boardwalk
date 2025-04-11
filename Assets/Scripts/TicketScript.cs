using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TicketScript : MonoBehaviour, IInteractable
{
    public TextMeshProUGUI ticketText;
    public string ticketID;

    void Start()
    {
        if (PlayerPrefs.GetInt(ticketID, 0) == 1)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        ticketText.text = "Tickets: " + ScoreManager.instance.tickets;
    }

    public void Interact()
    {
        if (!ScoreManager.instance.hasWon)
        {
            ScoreManager.instance.tickets++;
            PlayerPrefs.SetInt(ticketID, 1); // Save the state of this ticket
            Destroy(gameObject);
        }
    }
}
