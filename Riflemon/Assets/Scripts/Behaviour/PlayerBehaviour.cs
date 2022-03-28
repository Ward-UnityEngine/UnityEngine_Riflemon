using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviour : MonoBehaviour
{
    private Rigidbody2D rb;
    public RiflemonInput inputActions;
    private InputAction move;
    private InputAction interact;
    private Animator playerAnimator;


    public bool goingUp; //variable to check in other scripts
    public bool goingDown;
    private bool interactPressed;
    public bool interactActive;
    public bool interactOld;

    private float movementSpeed;
    public float movementSpeedOutside;
    public float movementSpeedInside;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        
    }

    private void OnEnable()
    {
        inputActions = new RiflemonInput();
        move = inputActions.Player.Move;
        interact = inputActions.Player.Interact;
    }

    public void enableInput()
    {
        
        move.Enable();
        if(!interact.enabled)
            interact.Enable();
    }

    private void Start()
    {
        //initiaize begin position
        BeginConditions beginConditions = Game_Manager.loadBeginConditions();
        if (beginConditions != null)
        {
            rb.transform.position = beginConditions.getBeginposition();
            if (beginConditions.getIsInside()) movementSpeed = movementSpeedInside;
            else movementSpeed = movementSpeedOutside;
            animateBegin(beginConditions.getBeginDirection());
        }
        else movementSpeed = movementSpeedOutside;
    }

    private void animateBegin(Vector2 beginDirection)
    {
        playerAnimator.SetFloat("Speed", 0);
        playerAnimator.SetFloat("Y_dir", beginDirection.y);
        playerAnimator.SetFloat("X_dir", 0);
    }


    private void FixedUpdate()
    {
        if (move.enabled)
        {
            Vector2 value = move.ReadValue<Vector2>();
                goingUp = value.y > 0.1f; //going up when opening doors
            goingDown = value.y < -0.1f;//going down through doors
            animate(value);
            rb.velocity = value.normalized * movementSpeed;

           
        }
        
    }

    private void Update()
    {
        setInteractButton();
    }

    private void setInteractButton()
    {
        interactOld = interactActive;
        interactActive = interact.ReadValue<float>() > 0.1f;
        if(interactActive && !interactOld)
        {
            //was pressed
            interactPressed = true;
        }
    }

    private void animate(Vector2 dir)
    {
        playerAnimator.SetFloat("Speed", rb.velocity.magnitude);

           
        if(Mathf.Abs(dir.x) > Mathf.Abs(dir.y))
        {
            //moving on the x-axis
            playerAnimator.SetFloat("X_dir", dir.x);
            playerAnimator.SetFloat("Y_dir", 0);
        }
        else
        {
            playerAnimator.SetFloat("Y_dir", dir.y);
            playerAnimator.SetFloat("X_dir", 0);
        }
        
    }

    public bool getInteractive()
    {
        if (interactPressed)
        {
            bool temp = interactPressed;
            interactPressed = false;
            return temp;
        }
        else return false;
    }
}
