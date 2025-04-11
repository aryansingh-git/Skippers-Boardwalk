using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UndergroundTimer : MonoBehaviour
{
    public GameObject timerUI;
    public TextMeshProUGUI timerText;
    private float timeLeft = 300;
    private bool timerStarted = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !timerStarted)
        {
            timerUI.SetActive(true);
            StartCoroutine(StartTimer());
            timerStarted = true;
        }
    }

    IEnumerator StartTimer()
    {
        while (timeLeft > 0)
        {
            if (!PauseMenu.isPaused)
            {
                yield return new WaitForSecondsRealtime(1);
                timeLeft--;
            }
            else
            {
                yield return null;
            }

            int minutes = Mathf.FloorToInt(timeLeft / 60F);
            int seconds = Mathf.FloorToInt(timeLeft - minutes * 60);

            timerText.text = string.Format("Time left: {0:0}:{1:00}", minutes, seconds);
        }

        timerUI.SetActive(false);
        SceneManager.LoadScene("Bad Ending");
    }
}
