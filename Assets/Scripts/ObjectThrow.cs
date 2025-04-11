using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Import the TMPro namespace
using UnityEngine.UI;

public class ObjectThrow : MonoBehaviour
{
    [SerializeField]
    private Transform spawnPoint;

    public Rigidbody ballPrefab;

    public float throwSpeed;

    public int throwCount = 0;
    private bool canThrow = true;
    public float upoffset = 0;

    private StartScreenPlayerController player;

    private List<GameObject> spawnedObjects = new List<GameObject>();

    public TextMeshProUGUI throwCountText; // Change this line

    public Image uiImage;

    public void ResetThrowCountText()
    {
        throwCountText.text = " ";
    }
    void Start()
    {
        player = GetComponent<StartScreenPlayerController>();
        uiImage.enabled = true;
    }

    // Update is called once per frame
    private bool isFirstThrow = true; // Add this line at the beginning of your class

    void Update()
    {
        if (canThrow && Input.GetMouseButtonDown(0) && !PauseMenu.isPaused)
        {
            if (isFirstThrow)
            {
                uiImage.enabled = false; // Disable the UI image on the first throw
                isFirstThrow = false; // Update the flag after the first throw
            }

            Rigidbody newBall = Instantiate(ballPrefab, spawnPoint.position, Quaternion.identity);
            spawnedObjects.Add(newBall.gameObject);
            newBall.AddForce(((spawnPoint.forward + (Vector3.up * upoffset)).normalized * throwSpeed));

            // Decrement throwCount after instantiation
            throwCount--;

            // Update throw count text after decrementing throwCount
            UpdateThrowCountText();

            if (throwCount <= 0)
            {
                canThrow = false;
                StartCoroutine(ResetSpeedAfterDelay(player.currentMinigame.waitTime));
            }
        }
    }



    // This function updates the throw count text
    void UpdateThrowCountText()
    {
        if (throwCount <= 0)
        {
            throwCountText.text = " ";
        }
        else
        {
            throwCountText.text = "Throws left: " + throwCount;
        }
    }


    public void DeleteAllSpawned()
    {
        for (int i = spawnedObjects.Count - 1; i >= 0; i--)
        {
            Destroy(spawnedObjects[i]);
        }
    }

    IEnumerator ResetSpeedAfterDelay(float seconds)
    {
        Debug.Log("Minigame timeout");
        yield return new WaitForSeconds(seconds);
        player.currentMinigame.EndGame();

    }

    // This function is called when the script is enabled
    void OnEnable()
    {
        canThrow = true;
        UpdateThrowCountText(); // Update the text when the script is enabled
    }
}
