using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator animator;
    private CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 horizontalVelocity = characterController.velocity;
        horizontalVelocity.y = 0;
        float speed = horizontalVelocity.magnitude;
        animator.SetFloat("speed", speed, 0.1f, Time.deltaTime);

        animator.SetBool("Grounded", characterController.isGrounded);

        if (characterController.isGrounded)
        {
            animator.SetBool("Jump", false);
            animator.SetBool("FreeFall", false);
        }
        else if (characterController.velocity.y < -0.1f)
        {
            animator.SetBool("FreeFall", true);
        }
    }

    public void TriggerJumpAnimation()
    {
        animator.SetBool("Jump", true);
    }
}
