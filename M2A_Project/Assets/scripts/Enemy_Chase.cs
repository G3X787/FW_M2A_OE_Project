using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform player; // Reference to the player's transform.
    public float moveSpeed = 3.0f; // Adjust this value to control the speed of the enemy.
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Calculate the direction to move towards the player.
        Vector2 direction = (player.position - transform.position).normalized;

        // Set the enemy's velocity to move only along x and y axes.
        rb.velocity = new Vector2(direction.x, direction.y) * moveSpeed;
    }
}