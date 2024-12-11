using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ThirdPersonMovement : MonoBehaviour
{
    public UnityEvent moveRight, moveLeft, moveUp, moveDown, noInput;
    public CharStats playerStats;
    public CharacterController characterController;

    [Header("Key Bindings")]
    public KeyCode forwardKey = KeyCode.W;
    public KeyCode backwardKey = KeyCode.S;
    public KeyCode leftKey = KeyCode.A;
    public KeyCode rightKey = KeyCode.D;

    [Header("Animator Settings")]
    public GameObject animatedObject; // Drag and drop your object here
    private Animator animator;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (animatedObject != null)
        {
            animator = animatedObject.GetComponent<Animator>();
        }
    }

    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        Vector3 moveDirection = Vector3.zero;
        bool isInput = false;

        if (Input.GetKey(forwardKey))
        {
            moveDirection += transform.forward;
            moveDown.Invoke();
            isInput = true;
        }
        if (Input.GetKey(backwardKey))
        {
            moveDirection -= transform.forward;
            moveUp.Invoke();
            isInput = true;
        }
        if (Input.GetKey(leftKey))
        {
            moveDirection -= transform.right;
            moveLeft.Invoke();
            isInput = true;
        }
        if (Input.GetKey(rightKey))
        {
            moveDirection += transform.right;
            moveRight.Invoke();
            isInput = true;
        }

        if (!isInput)
        {
            noInput.Invoke();
        }

        // Update the animator moving parameter
        if (animator != null)
        {
            animator.SetBool("moving", isInput);
        }

        // Normalize movement direction and apply speed
        moveDirection = moveDirection.normalized * playerStats.speed;

        // Apply only horizontal movement (no Y-axis adjustment)
        Vector3 newVelocity = new Vector3(moveDirection.x, rb.velocity.y, moveDirection.z);
        rb.velocity = newVelocity;
    }
}
