using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int score;
    public int tickets;
    public bool hasWon;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        tickets = PlayerPrefs.GetInt("Tickets", 0); // Load the saved number of tickets

        // Subscribe to the sceneLoaded event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // This method is called every time a new scene is loaded
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (mode == LoadSceneMode.Single)
        {
            ResetScore();
        }
    }

    public void AddScore(int points)
    {
        if (!hasWon)
        {
            score += points;
            tickets += 3; // Add 3 tickets for each score
        }
    }

    public void AddScoreBalloon(int points)
    {
        if (!hasWon)
        {
            score += points;
            tickets += points; // Add a ticket for each point scored

            if (tickets >= 10000) // Check if the ticket limit has been reached
            {
                tickets = 10000; // Ensure tickets do not exceed 50
            }
        }
    }

    public void ResetScore()
    {
        score = 0;
        tickets = 0;
        hasWon = false;
    }
}
