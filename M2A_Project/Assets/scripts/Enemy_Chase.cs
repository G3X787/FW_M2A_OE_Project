using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform player;  // Reference to the player's transform.
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateUpAxis = false;
        agent.updateRotation = false;
    }

    void Update()
    {
        // Check if the agent is not null and active.
        if (agent != null && agent.isActiveAndEnabled)
        {
            // Set the destination to the player's position.
            agent.SetDestination(player.position);
        }
    }
}