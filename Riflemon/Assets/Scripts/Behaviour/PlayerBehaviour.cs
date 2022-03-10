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

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
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
        rb.velocity = value.normalized * movementSpeed;
    }
}
