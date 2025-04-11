using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseEnable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true; // Enable the cursor
        Cursor.lockState = CursorLockMode.None; // Allow the cursor to move
    }
}
