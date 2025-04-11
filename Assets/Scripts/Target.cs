using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public AudioClip audioClip;
    public AudioSource audioSource;

    private void OnCollisionEnter(Collision collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();
        if (ball != null)
        {
            ScoreManager.instance.AddScoreBalloon(1); // Add a score of 1
            audioSource.clip = audioClip;
            audioSource.Play();
            gameObject.SetActive(false);
        }
    }
}
