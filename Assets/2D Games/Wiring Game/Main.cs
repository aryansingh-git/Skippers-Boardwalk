using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    static public Main Instance;

    public int switchCount;
    private int onCount = 0;

    public Carousel carousel; // Reference to the Carousel script

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Cursor.visible = true; // Enable the cursor
        Cursor.lockState = CursorLockMode.None; // Unlock the cursor
    }

    public void SwitchChange(int points)
    {
        onCount = onCount + points;
        if (onCount == switchCount)
        {
            StartCoroutine(ChangeScene());
        }
    }

    private IEnumerator ChangeScene()
    {
        ScoreManager.instance.tickets += 5;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Carousel.on = true; // Turn on the carousel

        yield return new WaitForSeconds(3); // Wait for 3 seconds
        SceneManager.UnloadSceneAsync("Wiring Game"); // Switch the scene to MainScene
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.UnloadSceneAsync("Wiring Game"); // Switch the scene to MainScene
            SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Additive);
        }
    }
}
