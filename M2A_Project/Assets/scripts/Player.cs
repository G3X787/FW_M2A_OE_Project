using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // Variables
    PlayerInputs inputs; // Creates a reference to PlayerInput (the input system).
    Rigidbody2D rb;
    public float speed;
    public float smoothTime;
    Vector2 movement = Vector2.zero;
    Vector2 targetVelocity;
    Vector2 velocitySmoothing;
    public float eKey;
    public int itemList = 0;

    void Awake()
    {
        inputs = new PlayerInputs(); // Initializes the variable
        rb = GetComponent<Rigidbody2D>();
        inputs.Player.HorizontalMovement.performed += ctx => Move(); // Reading the value given based off of what key was pressed ('a' for -1 and 'd' for 1)
        inputs.Player.VerticalMovement.performed += ctx => Move();
        inputs.Player.Interact.performed += ctx => InteractKey();
    }

    void FixedUpdate()
    {
        Move();
        InteractKey();
    }

    void Move()
    {
        movement.x = inputs.Player.HorizontalMovement.ReadValue<float>();
        movement.y = inputs.Player.VerticalMovement.ReadValue<float>();
        // Buttery Movement
        targetVelocity = movement * speed;
        rb.velocity = Vector2.SmoothDamp(rb.velocity, targetVelocity, ref velocitySmoothing, smoothTime);
        // Sharp Movement
        //rb.velocity = movement * speed;
    }

    void InteractKey()
    {
        eKey = inputs.Player.Interact.ReadValue<float>();
    }

    void Inventory()
    {

    }

    private void OnEnable()
    {
        inputs.Enable();
    }

    private void OnDisable()
    {
        inputs.Disable();
    }
}
