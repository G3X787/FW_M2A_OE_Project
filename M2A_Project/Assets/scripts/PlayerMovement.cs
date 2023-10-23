using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float runSpeed = 10f; // Speed when Shift is held down

    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Input handling for movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        movement = new Vector2(horizontalInput, verticalInput).normalized;

        // Check if Shift is held down to increase speed
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) ? runSpeed : walkSpeed;
        movement *= currentSpeed;
    }

    void FixedUpdate()
    {
        // Move the player
        rb.velocity = movement;

        // Check if the player is not moving and set velocity to zero to stop sliding
        if (movement == Vector2.zero)
        {
            rb.velocity = Vector2.zero;
        }
    }
}