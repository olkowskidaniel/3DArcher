using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Animator playerAnimator;
    Vector3 playerMovementVector3;
    Quaternion playerRotationQuaternion = Quaternion.identity;
    Rigidbody playerRigidbody;
    Vector3 moveVector;
    bool isMoving = false;
    public WeaponManager weaponManager;

    public FloatingJoystick floatingJoystick;
    public float moveForce = 3f;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        playerAnimator.SetBool("hasBow", weaponManager.GetHasWeapon());

        float horizontalInputValue = floatingJoystick.Horizontal;
        float verticalInputValue = floatingJoystick.Vertical;
        moveVector.Set(horizontalInputValue, 0f, verticalInputValue);
        playerRigidbody.velocity = new Vector3(horizontalInputValue * moveForce, playerRigidbody.velocity.y, verticalInputValue * moveForce);

        bool hasHorizontalInput = !Mathf.Approximately(horizontalInputValue, 0f);
        bool hasVerticalInput = !Mathf.Approximately(verticalInputValue, 0f);
        if(hasHorizontalInput || hasVerticalInput)
        {
            isMoving = true;
            transform.rotation = Quaternion.LookRotation(moveVector);
        } else
        {
            isMoving = false;
        }
        playerAnimator.SetBool("isMoving", isMoving);
        playerAnimator.SetFloat("speed", moveVector.magnitude);
    }
}
