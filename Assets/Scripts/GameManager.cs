using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        ResetTickets();
    }

    void ResetTickets()
    {
        PlayerPrefs.DeleteAll(); // This will delete all PlayerPrefs data
    }
}
