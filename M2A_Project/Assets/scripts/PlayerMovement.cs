using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust this value to set the movement speed.

    private Rigidbody2D rb;
    private Vector2 movementDirection = Vector2.zero;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float moveX = 0f;
        float moveY = 0f;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            moveY = 1f;
            movementDirection = Vector2.up;
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            moveY = -1f;
            movementDirection = Vector2.down;
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            moveX = -1f;
            movementDirection = Vector2.left;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            moveX = 1f;
            movementDirection = Vector2.right;
        }

        Vector2 movement = new Vector2(moveX, moveY);

        // If no movement key is pressed, stop moving.
        if (movement == Vector2.zero)
        {
            rb.velocity = Vector2.zero;
        }
        // If a movement key is pressed, move in the direction of the first key pressed.
        else if (movement == movementDirection)
        {
            rb.velocity = movement * moveSpeed;
        }
    }
}