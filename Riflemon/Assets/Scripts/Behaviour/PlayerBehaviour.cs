using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviour : MonoBehaviour
{
    private Rigidbody2D rb;
    public RiflemonInput inputActions;
    public float movementSpeed;
    private InputAction move;
    private Animator playerAnimator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        inputActions = new RiflemonInput();
        move = inputActions.Player.Move;
        move.Enable();
    }


    private void FixedUpdate()
    {
        Vector2 value = move.ReadValue<Vector2>();
        animate(value);
        rb.velocity = value.normalized * movementSpeed;
    }

    private void animate(Vector2 dir)
    {
        playerAnimator.SetFloat("Speed", rb.velocity.magnitude);
        playerAnimator.SetFloat("X_dir", dir.x);
        playerAnimator.SetFloat("Y_dir", dir.y);
    }
}
