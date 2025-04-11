using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField]
    private Transform startPoint;

    [SerializeField]
    private Transform endPoint;

    [SerializeField]
    private float moveTime = 5f;

    [SerializeField]
    private Rigidbody rigidbody;

    private void Start()
    {
        GameObject.FindAnyObjectByType<PauseMenu>().canPause = false;
        rigidbody.useGravity = false;
        StartCoroutine(MoveCamera(startPoint.position, endPoint.position, moveTime));
    }

    IEnumerator MoveCamera(Vector3 start, Vector3 end, float duration)
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            transform.position = Vector3.Lerp(start, end, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = end;
        rigidbody.useGravity = true;

        GameObject.FindAnyObjectByType<PauseMenu>().canPause = true;
        GameObject.FindGameObjectWithTag("Player").GetComponent<StartScreenPlayerController>().canMove = true;
        
    }
}
