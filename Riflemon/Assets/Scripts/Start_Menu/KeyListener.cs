using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class KeyListener : MonoBehaviour
{
    public GameObject[] startObjects;
    public GameObject[]  menuObjects;
    public RiflemonInput inputActions;
    private InputAction start;

    private void Awake()
    {
        inputActions = new RiflemonInput();
    }

    private void OnEnable() {
        start = inputActions.UI.Submit;
        start.Enable();
        start.performed += loadMenu;
    }
    private void OnDisable()
    {
        start.Disable();
    }


    private void Start()
    {
        loadStartMenu();
    }

    private void loadStartMenu() {
        foreach (GameObject o in startObjects)
        {
            o.SetActive(true);
        }
        foreach (GameObject o2 in menuObjects)
        {
            o2.SetActive(false);
        }
    }


    private void loadMenu(InputAction.CallbackContext context)
    {
        foreach( GameObject o in startObjects)
        {
            o.SetActive(false);
        }
        foreach(GameObject o2 in menuObjects)
        {
            o2.SetActive(true);
        }
    }

    

}
