using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eye : MonoBehaviour
{
    public GameObject eye;

    public float displayDuration = 2.0f; // 显示时间
    public float hideDuration = 0.2f; // 隐藏时间

    private float timer = 0.0f;
    private bool showingImage = true;

    private void OnEnable()
    {
        timer = 0.0f;
        showingImage = true;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (showingImage && timer >= displayDuration)
        {
            eye.SetActive(false);
            showingImage = false;
            timer = 0.0f;
        }
        else if (!showingImage && timer >= hideDuration)
        {
            eye.SetActive(true);
            showingImage = true;
            timer = 0.0f;
        }
    }
}
