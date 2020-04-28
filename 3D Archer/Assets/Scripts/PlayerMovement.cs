using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;
    private Vector3 moveDirection = Vector3.zero;

    CharacterController characterController;
    Animator animator;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        
    }
  
    void Update()
    {
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        moveDirection *= speed;

        characterController.Move(moveDirection * Time.deltaTime);

        if (moveDirection != Vector3.zero)
            animator.SetBool("isWalking", true);
        else
            animator.SetBool("isWalking", false);
    }
}
