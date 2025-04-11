using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public class MiniGame : MonoBehaviour
{
    public GameObject targetObject;

    protected StartScreenPlayerController player;

    public float waitTime = 3f;

    public Rigidbody thrownObject;
    public float throwSpeed;
    public int throwAmount;
    public float yOffset;

    public Image uiImage;

    private Vector3 oldPosition;
    private Quaternion oldRotation;

    public AudioSource audioSource;
    public AudioClip audioClip;

    private void OnTriggerEnter(Collider other)
    {
        StartScreenPlayerController temp = other.GetComponent<StartScreenPlayerController>();
        if (temp != null)
        {
            player = temp;
            uiImage.enabled = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        StartScreenPlayerController temp = other.GetComponent<StartScreenPlayerController>();
        if (temp != null)
        {
            player = null;
            uiImage.enabled = false;
        }
    }

    protected virtual void Update()
    {
        if (player != null && Input.GetKeyDown(KeyCode.G) && player.currentMinigame == null)
        {
            MovePlayerToTarget();
            StartGame();
        }
    }
    private void MovePlayerToTarget()
    {
        player.SetMovementToZero();
        player.walkingSpeed = 0;
        oldPosition = player.transform.position + Vector3.up * 0.2f;//saving the position when they press start game.
        oldRotation = player.transform.rotation;
       player.characterController.enabled = false;
        player.transform.position = targetObject.transform.position;
        player.transform.rotation = targetObject.transform.rotation;
        player.characterController.enabled = true;
    }

    protected virtual void StartGame()
    {
        player.currentMinigame = this;
        player.walkingSpeed = 0;
        ObjectThrow ot =  player.GetComponent<ObjectThrow>();
        ot.throwCount = throwAmount;
        ot.throwSpeed = throwSpeed;
        ot.ballPrefab = thrownObject;
        ot.upoffset = yOffset;

        uiImage.enabled = false;
    }

    public virtual void EndGame()
    {
        player.GetComponent<ObjectThrow>().DeleteAllSpawned();
       // player.transform.position = oldPosition;
       // player.transform.rotation = oldRotation;
        player.characterController.enabled = true;
        player.walkingSpeed = 5;
        player.canMove = true;
        player.currentMinigame = null;
        player = null;
        uiImage.enabled = false;

        audioSource.clip = audioClip;
        audioSource.Play();
    }

}
