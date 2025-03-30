using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    private Rigidbody rb;
    private PlayerControls playerControls;

    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpHeight = 5f;

    [Header("Input")]
    private Vector2 movementInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerControls = new PlayerControls();
        playerControls.BaseMovement.Enable();
    }
    private void OnEnable()
    {
        playerControls.BaseMovement.Jump.started +=  OnJump;
        playerControls.BaseMovement.Move.performed += OnMove;
        playerControls.BaseMovement.Move.canceled += OnMove;
        
    }

    private void Oisable()
    {
        playerControls.BaseMovement.Jump.started -=  OnJump;
        playerControls.BaseMovement.Move.performed -= OnMove;
        playerControls.BaseMovement.Move.canceled -= OnMove;       
    }

    private void Update()
    {
        //Move();
    }
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rb.AddForce(new Vector3(movementInput.x, 0, movementInput.y) * moveSpeed);
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            Debug.Log("Jump");
            rb.linearVelocity += new Vector3(0, jumpHeight, 0);
        }
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }
}
