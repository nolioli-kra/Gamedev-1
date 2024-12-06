using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ThirdPersonMovement : MonoBehaviour
{
    public UnityEvent moveRight, moveLeft, moveUp, moveDown;
    
    public CharStats playerStats;
    public CharacterController characterController;
    
    [Header("Key Bindings")]
    public KeyCode forwardKey = KeyCode.W;
    public KeyCode backwardKey = KeyCode.S;
    public KeyCode leftKey = KeyCode.A;
    public KeyCode rightKey = KeyCode.D;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        Vector3 moveDirection = Vector3.zero;

        // Check key inputs and set movement direction
        if (Input.GetKey(forwardKey))
        {
            moveDirection += transform.forward;
            moveDown.Invoke();
        }
        if (Input.GetKey(backwardKey))
        {
            moveDirection -= transform.forward;
            moveUp.Invoke();
        }
        if (Input.GetKey(leftKey))
        {
            moveDirection -= transform.right;
            moveLeft.Invoke();
        }
        if (Input.GetKey(rightKey))
        {
            moveDirection += transform.right;
            moveRight.Invoke();
        }

        // Normalize movement direction and apply speed
        moveDirection = moveDirection.normalized * playerStats.speed;

        // Apply only horizontal movement (no Y-axis adjustment)
        Vector3 newVelocity = new Vector3(moveDirection.x, rb.velocity.y, moveDirection.z);
        rb.velocity = newVelocity;
    }
}
