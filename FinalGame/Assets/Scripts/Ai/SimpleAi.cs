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
    public int waitBeforeApproachSeconds = 3;

    public UnityEvent OnPlayerDetected;
    public UnityEvent OnPlayerLost; 
    public UnityEvent OnInteract; 

    private int currentPatrolIndex;
    private AIState currentState;
    private Coroutine patrolCoroutine;

    void Start()
    {
        currentPatrolIndex = 0;
        currentState = AIState.Patrolling;
        
        if (patrolRoute == null || patrolRoute.positions.Length == 0)
        {
            Debug.LogWarning("No patrol points defined in the patrol route!");
            currentState = AIState.Idle;
        }

        StartPatrol();
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(player.position, transform.position);

        switch (currentState)
        {
            case AIState.Patrolling:
                if (distanceToPlayer <= detectionRadius)
                {
                    StopPatrol();
                    StartCoroutine(WaitBeforeApproach());
                }
                break;

            case AIState.Approaching:
                ApproachPlayer();
                if (distanceToPlayer > detectionRadius)
                {
                    currentState = AIState.Patrolling;
                    OnPlayerLost?.Invoke();
                    StartPatrol();
                }
                break;

            case AIState.Interacting:
                // stay in state until interaction completes or trigger resets it
                break;
        }
    }

    void StartPatrol()
    {
        if (patrolRoute != null && patrolRoute.positions.Length > 0)
        {
            patrolCoroutine = StartCoroutine(PatrolCoroutine());
        }
    }

    void StopPatrol()
    {
        if (patrolCoroutine != null)
        {
            StopCoroutine(patrolCoroutine);
            patrolCoroutine = null;
        }
    }

    IEnumerator PatrolCoroutine()
    {
        while (currentState == AIState.Patrolling)
        {
            Vector3 targetPoint = patrolRoute.positions[currentPatrolIndex];
            while (Vector3.Distance(transform.position, targetPoint) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPoint, patrolSpeed * Time.deltaTime);
                yield return null;
            }

            currentPatrolIndex = (currentPatrolIndex + 1) % patrolRoute.positions.Length;
            yield return null;
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
        StartPatrol();
    }

    IEnumerator WaitBeforeApproach()
    {
        currentState = AIState.Idle;
        yield return new WaitForSeconds(waitBeforeApproachSeconds);
        currentState = AIState.Approaching;
        OnPlayerDetected?.Invoke();
    }
}

public enum AIState
{
    Idle,
    Patrolling,
    Approaching,
    Interacting
}
