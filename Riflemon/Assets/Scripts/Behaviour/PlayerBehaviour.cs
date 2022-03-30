using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

public class PlayerBehaviour : MonoBehaviour
{
    
    public RiflemonInput inputActions;
    private InputAction move;
    private InputAction interact;
    private InputAction shoot;


    private Rigidbody2D rb;
    private Animator playerAnimator;
    private GunHandlerBehaviour gunHandlerBehaviour;


    public bool goingUp; //variable to check in other scripts
    public bool goingDown;
    private bool interactPressed;
    public bool interactActive;
    public bool interactOld;
    private bool isInside = false;
    private bool keyboardUsed;
    private Vector2 facingDirection;
    private Vector2 diagonalFacing;

    private float movementSpeed;
    public float movementSpeedOutside;
    public float movementSpeedInside;
    public int diagonalLatency;
    private int diagonalLatencyCounter;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        gunHandlerBehaviour = GetComponentInChildren<GunHandlerBehaviour>();
        
    }

    private void OnEnable()
    {
        inputActions = new RiflemonInput();
        move = inputActions.Player.Move;
        interact = inputActions.Player.Interact;
        shoot = inputActions.Player.Fire;

    }

    public void enableInput()
    {
        
        move.Enable();
        move.performed += updateControllerType;
        if (!isInside)
        {
            shoot.Enable();
            shoot.performed += fireCalled;
        }
        else
        {
            shoot.Disable();
        }
       
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
            isInside = beginConditions.getIsInside();
            if (isInside) movementSpeed = movementSpeedInside;
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

    private void updateControllerType(InputAction.CallbackContext context)
    {
        if (context.control.device.ToString().Equals("Keyboard:/Keyboard"))
        {
            //keyboard is being used
            //keyboardUsed = true;
        }
        else
            keyboardUsed = false;
    }
    private void movePlayer()
    {
        if (move.enabled)
        {
            Vector2 value = move.ReadValue<Vector2>();
            goingUp = value.y > 0.1f; //going up when opening doors
            goingDown = value.y < -0.1f;//going down through doors
            animate(value);
            rb.velocity = value.normalized * movementSpeed;

                bool xAxis = Mathf.Abs(value.x) > 0.1f;
                bool yAxis = Mathf.Abs(value.y) > 0.1f;
                if (xAxis && yAxis)
                {
                    diagonalLatencyCounter = 0;
                    facingDirection = value;
                    diagonalFacing = value;
                }
                else
                {
                    if (xAxis || yAxis)
                    {

                        facingDirection = value;

                    }
                    else if(keyboardUsed)
                    {
                        if (diagonalLatencyCounter < diagonalLatency)
                        {
                            //user wanted to stay diagonal
                            facingDirection = diagonalFacing;
                        }
                    }
                    if (diagonalLatencyCounter < diagonalLatency)
                        diagonalLatencyCounter++;
                }

        }
    }


    private void FixedUpdate()
    {
        movePlayer();
        
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

    public void fireCalled(InputAction.CallbackContext context)
    {
        if (gunHandlerBehaviour != null)
        {
            gunHandlerBehaviour.shoot(facingDirection.normalized);
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
