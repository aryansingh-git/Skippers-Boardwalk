using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ShowUI : MonoBehaviour
{
    public float delay = 10.0f; 
    private Image image; 

    void Start()
    {
        image = GetComponent<Image>(); 
        image.enabled = false; 
        StartCoroutine(EnableAfterSeconds(delay)); 
    }

    IEnumerator EnableAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        image.enabled = true; // Enable the Image after the delay
    }
}
