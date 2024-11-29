using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class SimpleAI : MonoBehaviour
{
    public VectorLocation patrolRoute;
    public float patrolSpeed = 2f;
    public float approachSpeed = 4f;
    public float detectionRadius = 5f; 
    public Transform player;
    
    public UnityEvent OnPlayerDetected;
    public UnityEvent OnPlayerLost; 
    public UnityEvent OnInteract; 

    private int currentPatrolIndex;
    private AIState currentState;

    void Start()
    {
        currentPatrolIndex = 0;
        currentState = AIState.Patrolling;
        
        if (patrolRoute == null || ((ICollection)patrolRoute.positions).Count == 0)
        {
            Debug.LogWarning("No patrol points defined in the patrol route!");
            currentState = AIState.Idle;
        }
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(player.position, transform.position);

        switch (currentState)
        {
            case AIState.Patrolling:
                Patrol();
                if (distanceToPlayer <= detectionRadius)
                {
                    currentState = AIState.Approaching;
                    OnPlayerDetected?.Invoke();
                }
                break;

            case AIState.Approaching:
                ApproachPlayer();
                if (distanceToPlayer > detectionRadius)
                {
                    currentState = AIState.Patrolling;
                    OnPlayerLost?.Invoke();
                }
                break;

            case AIState.Interacting:
                // stay in state until interaction completes or trigger resets it
                break;
        }
    }

    void Patrol()
    {
        if (patrolRoute == null || ((ICollection)patrolRoute.positions).Count == 0) return;

        Vector3 targetPoint = patrolRoute.positions[currentPatrolIndex];
        transform.position = Vector3.MoveTowards(transform.position, targetPoint, patrolSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPoint) < 0.1f)
        {
            currentPatrolIndex = (currentPatrolIndex + 1) % ((ICollection)patrolRoute.positions).Count;
        }
    }

    void ApproachPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, approachSpeed * Time.deltaTime);
    }

    public void TriggerInteraction()
    {
        currentState = AIState.Interacting;
        OnInteract?.Invoke();
    }

    public void ResetToPatrolling()
    {
        currentState = AIState.Patrolling;
    }
}

public enum AIState
{
    Idle,
    Patrolling,
    Approaching,
    Interacting
}
