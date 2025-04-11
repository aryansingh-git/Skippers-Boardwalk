using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class StartScreenPlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float walkingSpeed = 5.0f;
    public float runningSpeed = 10.0f;
    public float jumpSpeed = 7.0f;
    public float gravity = 25.0f;
    public float normalHeight, crouchHeight;

    [Header("Look Settings")]
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;

    [Header("Ticket Settings")]
    public int ticketCount = 0;

    public CharacterController characterController;
    private Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0;

   
    public bool canMove = true;

    public MiniGame currentMinigame;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        canMove = false;
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (canMove == false || PauseMenu.isPaused) 
        {
            return;
        }


        characterController.detectCollisions = true;

        if (Input.GetKeyDown(KeyCode.C))
        {
            characterController.height = crouchHeight;
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            characterController.height = normalHeight;
        }

        if (canMove)
        {
            if (currentMinigame == null)
            {
                HandleMovementInput();
            }

            HandleMouseLook();
        }

        ApplyGravity();

        characterController.Move(moveDirection * Time.deltaTime);
    }

    public void SetMovementToZero()
    {
        moveDirection = Vector3.zero;
    }

    void HandleMovementInput()
    {
        Vector3 forward = transform.forward;
        Vector3 right = transform.right;

        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical");
        float curSpeedY = (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal");

        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (Input.GetButton("Jump") && characterController.isGrounded)
        {
            moveDirection.y = jumpSpeed;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }
    }

    void HandleMouseLook()
    {
        rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
    }

    void ApplyGravity()
    {
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }
    }
}
