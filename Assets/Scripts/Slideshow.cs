using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Slideshow : MonoBehaviour
{
    private float holdTime = 2.0f;
    private float timer; 
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        StartCoroutine(LoadSceneAfterDelay(245));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            timer += Time.deltaTime; 

            if (timer > holdTime)
            {
                SceneManager.LoadScene("MainScene"); 
            }
        }

        else if (Input.GetKeyUp(KeyCode.Space))
        {
            timer = 0;
        }
    }

    IEnumerator LoadSceneAfterDelay(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene("MainScene");
    }
}
