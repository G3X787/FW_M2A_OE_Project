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
    Vector2 movement = Vector2.zero;
    public InteractableObject interactableObject;
    public InteractType interactType;
    

    void Awake()
    {
        inputs = new PlayerInputs(); // Initializes the variable
        rb = GetComponent<Rigidbody2D>();
        inputs.Player.HorizontalMovement.performed += ctx => Move(); // Reading the value given based off of what key was pressed ('a' for -1 and 'd' for 1)
        inputs.Player.VerticalMovement.performed += ctx => Move();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        movement.x = inputs.Player.HorizontalMovement.ReadValue<float>();
        movement.y = inputs.Player.VerticalMovement.ReadValue<float>();
        rb.velocity = movement * speed;
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
