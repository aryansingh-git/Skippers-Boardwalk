using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIImageTrigger : MonoBehaviour
{
    public Image myImage; // Reference to the UI image

    void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is the player
        if (other.gameObject.CompareTag("Player"))
        {
            // Enable the image
            myImage.enabled = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Check if the exiting object is the player
        if (other.gameObject.CompareTag("Player"))
        {
            // Disable the image
            myImage.enabled = false;
        }
    }
}
