using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 1;
    public float runSpeed = 10f;
    private bool isRunning;

    [Header("Rotation")]
    public float rotationSpeed = 5;
    [Header("Jumping")]
    public float jumpForce = 15f;
    private bool canDoubleJump;
    public bool toogleDoubleJump;

    [Header("Gravity")]
    private float gravity = -9.81f;
    public float gravityMultiplier = 5f;

    private Vector2 movementVector;
    private CharacterController characterController;
    private Vector3 moveDirection;
    private float verticalVelocity;

    private AnimationController animationController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animationController = GetComponent<AnimationController>();
    }

    // Update is called once per frame
    void Update()
    {
        ApplyGravity();
        ApplyRotation();
        ApplyMovement();
    }

    void OnRun(InputValue runValue)
    {
        isRunning = runValue.isPressed;
    }

    void OnMove(InputValue movementValue)
    {
        movementVector = movementValue.Get<Vector2>();
        Vector3 camForward = Camera.main.transform.forward;
        Vector3 camRight = Camera.main.transform.right;
        camForward.y = 0;
        camRight.y = 0;

        moveDirection = camRight.normalized * movementVector.x + camForward.normalized * movementVector.y;
        
    }

    void OnJump(InputValue jumpValue)
    {
        if (characterController.isGrounded)
        {
            verticalVelocity = jumpForce;
            animationController.TriggerJumpAnimation();
        }
        else if(canDoubleJump == true && toogleDoubleJump == true)
        {
            verticalVelocity = jumpForce;
            canDoubleJump = false;
            animationController.TriggerJumpAnimation();
        }
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
        if(movementVector.sqrMagnitude > 0.01f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
        


    public void ApplyMovement()
    {   
        float currentSpeed;

        if (isRunning)
        {
            currentSpeed = runSpeed;
        }
        else
        {
            currentSpeed = speed;
        }

        Vector3 finalVelocity = moveDirection * currentSpeed;
        finalVelocity.y = verticalVelocity;
        characterController.Move(finalVelocity * Time.deltaTime);
    }
}
