using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    private float holdTime = 2.0f;
    private float timer; 
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        StartCoroutine(LoadSceneAfterDelay(6));
    }

    IEnumerator LoadSceneAfterDelay(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene("MainMenu");
    }
}
