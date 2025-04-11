using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    // Assuming the spotlight is attached to the same GameObject as this script
    private Light spotlight;

    private void Start()
    {
        // Get the Light component
        spotlight = GetComponent<Light>();
        spotlight.enabled = false;
    }

    private void Update()
    {
        // Check if the 'F' key was pressed
        if (Input.GetKeyDown(KeyCode.F))
        {
            // Toggle the light on/off
            spotlight.enabled = !spotlight.enabled;
        }
    }
}