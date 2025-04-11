using UnityEngine;

public class RotateCube : MonoBehaviour
{
    public float speed = 50f; // rotation speed
    public Vector3 centerPoint = Vector3.zero; // center of rotation

    void Update()
    {
        // Calculate the rotation angle around the Y axis (for clockwise rotation)
        float angle = speed * Time.deltaTime;

        // Rotate the cube around the center point
        transform.RotateAround(centerPoint, Vector3.up, -angle);
    }
}
