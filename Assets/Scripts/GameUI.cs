using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI ticketsText;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UpdateUI();
    }

    void Update()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        if (sceneName == "MainScene" || sceneName == "Respawn")
        {
            scoreText.enabled = false;
        }
        else
        {
            scoreText.enabled = true;
            scoreText.text = "Score: " + ScoreManager.instance.score;
        }
        ticketsText.text = "Tickets: " + ScoreManager.instance.tickets;
    }
}
