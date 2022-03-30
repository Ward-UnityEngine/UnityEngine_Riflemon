using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main_Menu_Listener : MonoBehaviour
{
    private RiflemonInput inputActions;
    private InputAction navigate;
    private InputAction submit;
    public MyButton loadButton;
    public MyButton saveButton;
    public MyButton settingsButton;
    public MyButton quitButton;
    public MyButton newGameButton;
    private MyButton[] buttons;
    private int activeButton = 0;



    private void Awake()
    {
        inputActions = new RiflemonInput();

        
    }

    private void OnDisable()
    {
        navigate.Disable();
        submit.Disable();
        navigate.performed -= navigateMainMenu;
        submit.performed -= clickOnButton;

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
        activeButton = 0;
        buttons[activeButton].highlight(true);
        //for some fucked up reason in the title scene the button presses trigger twice
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
        Button.ButtonClickedEvent newGame = new Button.ButtonClickedEvent();
        newGame.AddListener(new_game_clicked);
        newGameButton.setOnClick(newGame);
        buttons = new MyButton[] { newGameButton, loadButton, saveButton, settingsButton, quitButton };
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

    public void new_game_clicked()
    {

        SceneManager.LoadScene(1);
    }



    private void navigateMainMenu(InputAction.CallbackContext context)
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

    private void clickOnButton(InputAction.CallbackContext context)
    {
        
            buttons[activeButton].click();
        
    }
}
