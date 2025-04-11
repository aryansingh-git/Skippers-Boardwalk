using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeInOut : MonoBehaviour
{
    public CanvasGroup canvasGroup;

    void Start()
    {
        StartCoroutine(FadeInOutCoroutine());
    }

    IEnumerator FadeInOutCoroutine()
    {
        float t = 0;
        // Fade in over 1 second
        while ( t < 1f)
        {
            t += Time.deltaTime;
            canvasGroup.alpha = t;
            yield return null;
        }

        t = 1;
        canvasGroup.alpha = t;
        yield return new WaitForSeconds(10);

        // Fade out over 1 second
        while (t > 0f)
        {
            t -= Time.deltaTime;
            canvasGroup.alpha = t;
            yield return null;
        }
        t = 0;
        canvasGroup.alpha = t;
    }
}
