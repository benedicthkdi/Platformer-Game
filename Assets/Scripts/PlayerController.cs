using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Vector2 movementVector;
    private CharacterController characterController;
    private Vector3 moveDirection;
    public float speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        ApplyMovement();
    }

    void OnMove(InputValue movementValue)
    {
        movementVector = movementValue.Get<Vector2>();
        moveDirection = new Vector3(movementVector.x, 0, movementVector.y);
        
    }

    public void ApplyMovement()
    {
        Vector3 finalVelocity = moveDirection * speed;
        characterController.Move(finalVelocity * Time.deltaTime);
    }
}
