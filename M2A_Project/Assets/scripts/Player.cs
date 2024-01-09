using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Variables
    PlayerInputs inputs; // Creates a reference to PlayerInput (the input system).
    Rigidbody2D rb;
    Vector2 movement = Vector2.zero;
    Vector2 prevMovement;
    Vector2 targetVelocity;
    Vector2 velocitySmoothing;
    public float eKey;

    SpriteRenderer sr;
    
    [Header("Speed Variables")]
    [SerializeField] float speed;
    [SerializeField] float smoothTime;
    [SerializeField] float sprintBoost;

    // Animation Variables
    Animator animator;
    bool isMoving = false;

    void Awake()
    {
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
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
        prevMovement = movement;
        movement.x = inputs.Player.HorizontalMovement.ReadValue<float>();
        movement.y = inputs.Player.VerticalMovement.ReadValue<float>();

        // Buttery Movement
        targetVelocity = movement * (speed + (inputs.Player.Sprint.ReadValue<float>() * sprintBoost));
        rb.velocity = Vector2.SmoothDamp(rb.velocity, targetVelocity, ref velocitySmoothing, smoothTime);


        // Checks if the player is moving
        if (movement != Vector2.zero)
        {
            // Declares the player is moving
            isMoving = true;
        }
        else
        {
            // Declares the player is not moving
            isMoving = false;
        }

        // Sets the animator paramter
        animator.SetBool("IsMoving", isMoving);
    }

    void InteractKey()
    {
        eKey = inputs.Player.Interact.ReadValue<float>();
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
