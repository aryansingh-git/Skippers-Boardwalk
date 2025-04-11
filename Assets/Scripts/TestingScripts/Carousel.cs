using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carousel : MonoBehaviour
{
    public static bool on = false;
    public float speed;
    public GameObject carouselCenterObject; // The GameObject representing the center of the carousel

    // Start is called before the first frame update
    void Start()
    {
        on = false; // Set on to false at the start
    }

    // Update is called once per frame
    void Update()
    {
        if (on)
        {
            // Rotate around the carousel center in the Y axis in the opposite direction
            transform.RotateAround(carouselCenterObject.transform.position, Vector3.up, -speed * Time.deltaTime);
        }
    }
}
