using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform player;  // Reference to the player's transform.
    private NavMeshAgent agent;

    // The maximum distance from the player to consider them on the NavMesh.
    public float maxDistanceToNavMesh = 1.0f;

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
            // Check if the player's position is on the NavMesh.
            NavMeshHit hit;
            if (NavMesh.SamplePosition(player.position, out hit, maxDistanceToNavMesh, NavMesh.AllAreas))
            {
                // Set the destination to the player's position.
                agent.SetDestination(hit.position);
            }
            else
            {
                // Player is not on the NavMesh, move randomly.
                MoveRandomly();
            }
        }
    }

    // Function to move the enemy randomly within the NavMesh area.
    void MoveRandomly()
    {
        // Generate a random point within the NavMesh bounds.
        Vector3 randomPosition = RandomNavMeshPoint();

        // Set the destination to the random position.
        agent.SetDestination(randomPosition);
    }

    // Helper function to generate a random point within the NavMesh bounds.
    Vector3 RandomNavMeshPoint()
    {
        NavMeshTriangulation navMeshData = NavMesh.CalculateTriangulation();

        int randomIndex = Random.Range(0, navMeshData.vertices.Length);

        return navMeshData.vertices[randomIndex];
    }
}