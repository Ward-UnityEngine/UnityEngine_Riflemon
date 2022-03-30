using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CanvasListener : MonoBehaviour
{
    public GameObject menu;
    public RiflemonInput inputActions;
    private InputAction pauze;
    private PlayerBehaviour playerBehaviour;

    private void OnEnable()
    {
        inputActions = new RiflemonInput();
        pauze = inputActions.UI.OpenCloseMenu;
        pauze.Enable();
        pauze.performed += pauze_callback;

        playerBehaviour = FindObjectOfType<PlayerBehaviour>();
    }

    private void pauze_callback(InputAction.CallbackContext context)
    {
        
        if(menu.activeSelf)
        {
            menu.SetActive(false);
            Time.timeScale = 1;
            playerBehaviour.enableInput();
        }
        else
        {
            menu.SetActive(true);
            Time.timeScale = 0;
            playerBehaviour.disableInput();
        }
    }

}
