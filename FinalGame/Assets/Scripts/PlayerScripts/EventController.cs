using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class EventController : MonoBehaviour
{
    public UnityEvent<Vector2> onMoveInput; 
    public UnityEvent onJumpInput, onLanding, whenAirborne, coinCollect, enemyTouch, mazeComplete, startEvent, endEvent;
    
    public GameObject player;
    public CharStats playerStats;
    public isGrounded playerGrounded;

    [SerializeField] private float groundCheckLength = 0.1f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float objHeight = 1.8f;
    private bool groundCheck = false;
    
    private Vector3 velocity;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        startEvent.Invoke();
    }

    private void FixedUpdate()
    {
        Gravity();
        CheckGrounded();
    }

    private void Gravity()
    {
        if (playerGrounded.isOnGround == false)
        {
            rb.AddForce(Physics.gravity * playerStats.gravity, ForceMode.Acceleration);
        }
    }
    
    public void CheckGrounded()
    {
        Vector3 rayStart = transform.position - new Vector3(0, objHeight / 2, 0);
        
        //downwards ray from player’s position
        groundCheck = Physics.Raycast(rayStart, Vector3.down, groundCheckLength, groundLayer);

        //ray gizmo
        Debug.DrawRay(rayStart, Vector3.down * groundCheckLength, Color.red);
        
        if (groundCheck == true)
        {
            //Debug.Log("Player is grounded.");
            onLanding.Invoke();
        }
        else
        {
            //Debug.Log("Player is not grounded.");
            whenAirborne.Invoke();
        }
        
        playerGrounded.isOnGround = groundCheck;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NPC"))
        {
            enemyTouch.Invoke();
        }
        
        if (other.CompareTag("Coin"))
        {
            //Debug.Log("Coin collected");
            coinCollect.Invoke();
        }

        if (other.CompareTag("End"))
        {
            Debug.Log("maze complete");
            mazeComplete.Invoke();
        }
    }

    public VectorLocation respawnPoint;
    public void Respawn(Transform player)
    {
        player.position = respawnPoint.positions[0];
    }
    
}
