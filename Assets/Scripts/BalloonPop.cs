using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    public GameObject particleEffectPrefab;
    public AudioClip audioClip;
    public AudioSource audioSource;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Dart")
        {
            PopBalloon();
            audioSource.clip = audioClip;
            audioSource.Play();


        }
    }    

    void PopBalloon()
    {
        ScoreManager.instance.AddScoreBalloon(1); 
        
        GameObject particleEffect = Instantiate(particleEffectPrefab, transform.position, Quaternion.identity);  // Instantiate a particle effect
        Destroy(particleEffect, particleEffect.GetComponent<ParticleSystem>().main.duration); 

        gameObject.SetActive(false); 
    }
}
