using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Main_Menu_Listener : MonoBehaviour
{
    private RiflemonInput inputActions;
    private InputAction navigate;
    private InputAction submit;
    public MyButton loadButton;
    public MyButton saveButton;
    public MyButton settingsButton;
    public MyButton quitButton;
    private MyButton[] buttons;
    private int activeButton = 0;

    private bool buttonPressed = true;
    private bool spacePressed = true;

    private void Awake()
    {
        inputActions = new RiflemonInput();
    }

    private void OnEnable()
    {
        navigate = inputActions.UI.Navigate;
        navigate.Enable();
        navigate.performed += navigateMainMenu;

        submit = inputActions.UI.Submit;
        submit.Enable();
        submit.performed += clickOnButton;


    }
    private void Start()
    {
        initButtons();
        loadButton.highlight(true);
    }



    private void initButtons()
    {
        Button.ButtonClickedEvent eventQuit = new Button.ButtonClickedEvent();
        eventQuit.AddListener(quit_clicked);
        quitButton.setOnClick(eventQuit);
        Button.ButtonClickedEvent eventSet = new Button.ButtonClickedEvent();
        eventSet.AddListener(settings_clicked);
        settingsButton.setOnClick(eventSet);
        Button.ButtonClickedEvent eventLoad = new Button.ButtonClickedEvent();
        eventLoad.AddListener(load_clicked);
        loadButton.setOnClick(eventLoad);
        Button.ButtonClickedEvent eventSave = new Button.ButtonClickedEvent();
        eventSave.AddListener(save_clicked);
        saveButton.setOnClick(eventSave);
        buttons = new MyButton[] { loadButton, saveButton, settingsButton, quitButton };
    }

    public void load_clicked()
    {
        Debug.Log("load");
    }
    public  void save_clicked()
    {
        Save_Manager.save_game();
        Debug.Log("Save");
    }
    public void settings_clicked()
    {
        Debug.Log("Settings");
    }
    public void quit_clicked()
    {
        Application.Quit();
    }


    private void OnDisable()
    {
        navigate.Disable();
        submit.Disable();
    }

    private void navigateMainMenu(InputAction.CallbackContext context)
    {
        if (buttonPressed) //so that we only register button being released and not it being pressed and released or something. Seems like a bug imo tbh
        {
            Vector2 nav = context.ReadValue<Vector2>();
            buttons[activeButton].highlight(false);
            if (nav.y < -0.5f)
            {
                //going up
                activeButton++;
                if (activeButton > buttons.Length - 1)
                {
                    activeButton = 0;
                }
            }
            else
            {
                activeButton--;
                if (activeButton < 0)
                {
                    activeButton = buttons.Length - 1;
                }
            }
            buttons[activeButton].highlight(true);
        }
        buttonPressed =  !buttonPressed;
        
    }

    private void clickOnButton(InputAction.CallbackContext context)
    {
        if (spacePressed)
        {
            buttons[activeButton].click();
        }
        spacePressed = !spacePressed;
    }
}
