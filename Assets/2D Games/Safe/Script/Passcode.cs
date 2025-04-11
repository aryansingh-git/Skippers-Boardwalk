using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Add this line

public class Passcode : MonoBehaviour
{
    string Code = "3920";
    string Nr = null;
    int NrIndex = 0;
    string alpha;
    public Text UiText = null;
    public RawImage FlashScreen = null;
    public string newSceneName; // Name of the scene to load

    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void CodeFunction(string Numbers)
    {
        NrIndex++;
        Nr = Nr + Numbers;
        UiText.text = Nr;
    }

    public void Enter()
    {
        if (Nr == Code)
        {
            Debug.Log("Correct");
            UiText.text = "Correct";
            StartCoroutine(FlashAndLoadScene(Color.green)); // Modify this line
        }
        else
        {
            Debug.Log("Incorrect");
            UiText.text = "Incorrect";
            StartCoroutine(Flash(Color.red));
            Delete();
        }
    }

    public void Delete()
    {
        NrIndex++;
        Nr = null;
        UiText.text = "Enter Passcode";
    }

    IEnumerator Flash(Color flashColor)
    {
        FlashScreen.color = flashColor;
        FlashScreen.canvasRenderer.SetAlpha(1.0f);
        yield return new WaitForSeconds(0.5f);
        FlashScreen.color = Color.white;
    }

    IEnumerator FlashAndLoadScene(Color flashColor) // Add this method
    {
        FlashScreen.color = flashColor;
        FlashScreen.canvasRenderer.SetAlpha(1.0f);
        yield return new WaitForSeconds(1.0f); // Wait for 3 seconds
        SceneManager.LoadScene(newSceneName); // Load the new scene
    }
}
