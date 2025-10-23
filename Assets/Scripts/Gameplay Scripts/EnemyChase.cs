using UnityEngine;
using UnityEngine.AI;

public class EnemyChase : MonoBehaviour
{
    [Header("Player Detection")]
    public Transform player;
    public float detectionRadius = 15f;     // Vision radius
    public LayerMask obstacleMask;          // Obstacles for raycast

    [Header("Movement")]
    public float stoppingDistance = 5f;
    public float agentSpeed = 70f;

    private NavMeshAgent agent;
    private Vector3 initialPosition;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = agentSpeed;
        agent.stoppingDistance = stoppingDistance;
        agent.autoBraking = true;
        agent.Warp(transform.position);     // Ensure agent starts on NavMesh

        initialPosition = transform.position;
    }

    void Update()
    {
        if (player == null) return;

        bool playerVisible = false;

        // Points to check on player
        Vector3[] checkPoints = new Vector3[]
        {
            player.position,                   
            player.position + Vector3.up * 5f,   
            player.position + Vector3.down * 5f  
        };

        // Detects colliders in vision radius
        Collider[] hits = Physics.OverlapSphere(transform.position, detectionRadius);

        foreach (Collider col in hits)
        {
            if (col.transform == player)
            {
                // Raycast for line-of-sight
                foreach (Vector3 point in checkPoints)
                {
                    Vector3 dir = (point - transform.position).normalized;
                    float distance = Vector3.Distance(transform.position, point);

                    if (!Physics.Raycast(transform.position, dir, distance, obstacleMask))
                    {
                        playerVisible = true;
                        break;
                    }
                }

                if (playerVisible) break;
            }
        }

        if (playerVisible)
        {
            // Chase player
            agent.isStopped = false;
            agent.SetDestination(player.position);
        }
        else
        {
            // Returns to start position if player is out of view
            if (Vector3.Distance(transform.position, initialPosition) > 1f)
            {
                agent.isStopped = false;
                agent.SetDestination(initialPosition);
            }
            else
            {
                agent.isStopped = true; // Stop when reaches player
            }
        }
    }
}
