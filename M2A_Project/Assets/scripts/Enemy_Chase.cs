using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform player; // Reference to the player's transform.
    public float moveSpeed = 3.0f; // Adjust this value to control the speed of the enemy.

    private Vector2 currentDirection = Vector2.zero; // Current movement direction.

    void Update()
    {
        // Calculate the direction to move towards the player.
        Vector2 direction = (player.position - transform.position).normalized;

        // Check if the current direction is diagonal and if it's time to change direction.
        if (IsDiagonal(currentDirection) || Vector2.Dot(currentDirection, direction) <= 0)
        {
            // Change direction to the axis that aligns with the player's position.
            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
            {
                currentDirection = new Vector2(direction.x, 0);
            }
            else
            {
                currentDirection = new Vector2(0, direction.y);
            }
        }

        // Move the enemy.
        transform.position += (Vector3)currentDirection * moveSpeed * Time.deltaTime;
    }

    // Check if the vector represents diagonal movement.
    bool IsDiagonal(Vector2 vector)
    {
        return Mathf.Approximately(vector.x, vector.y);
    }
}