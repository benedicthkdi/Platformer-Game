using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float walkSpeed = 5f;
    public float sprintSpeed = 10f;
    private bool isSprinting;

    [Header("Rotation")]
    public float rotationSpeed = 5;

    [Header("Jumping")]
    public float jumpForce = 15f;
    private bool canDoubleJump;
    public bool toogleDoubleJump = true;

    [Header("Gravity")]
    public float gravityMultiplier = 5f;
    private float gravity = -9.81f;

    private Vector2 movementVector;
    private CharacterController characterController;
    private Vector3 moveDirection;
    private float verticalVelocity;

    [Header("Virtual Camera")]
    public CinemachineVirtualCamera virtualCamera;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void OnMove(InputValue movementValue)
    {
        movementVector = movementValue.Get<Vector2>();
        
        Vector3 camForward = Camera.main.transform.forward;
        Vector3 camRight = Camera.main.transform.right;
        camForward.y = 0f;
        camRight.y = 0f;
        
        moveDirection = camRight.normalized * movementVector.x + camForward.normalized * movementVector.y;
        
    }

    void OnJump(InputValue value)
    {
        if (characterController.isGrounded)
        {
            verticalVelocity = jumpForce;
        }
        else if (canDoubleJump && toogleDoubleJump)
        {
            verticalVelocity = jumpForce;
            canDoubleJump = false;
        }
    }

    void OnSprint(InputValue value)
    {
        isSprinting = value.isPressed;
    }

    void Update()
    {
        ApplyGravity();
        ApplyRotation();
        ApplyMovement();
    }

    public void ApplyGravity()
    {
        if (characterController.isGrounded && verticalVelocity < 0f)
        {
            verticalVelocity = -1f;
            canDoubleJump = true;
        }
        else
        {
            verticalVelocity += gravity * gravityMultiplier * Time.deltaTime;
        }
    }

    public void ApplyRotation()
    {
        if (movementVector.sqrMagnitude > 0.01f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    public void ApplyMovement()
    {
        float currentSpeed;

        if (isSprinting && characterController.isGrounded)
        {
            currentSpeed = sprintSpeed;
        }
        else
        {
            currentSpeed = walkSpeed;
        }

        Vector3 finalVelocity = moveDirection * currentSpeed;
        finalVelocity.y = verticalVelocity;
        characterController.Move(finalVelocity * Time.deltaTime);
    }

    public void Respawn(Vector3 spawnPosition, Quaternion spawnRotation)
    {
        characterController.enabled = false;
        transform.position = spawnPosition;
        transform.rotation = spawnRotation;
        characterController.enabled = true;

        verticalVelocity = 0f;

        movementVector = Vector2.zero;
        moveDirection = Vector3.zero;

        virtualCamera.PreviousStateIsValid = false;
    }
}
