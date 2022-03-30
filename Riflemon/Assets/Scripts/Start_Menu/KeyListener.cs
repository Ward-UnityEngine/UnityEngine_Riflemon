using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class KeyListener : MonoBehaviour
{
    public GameObject[] startObjects;
    public GameObject[]  menuObjects;
    public RiflemonInput inputActions;
   

    private void Update()
    {
        if(Keyboard.current.anyKey.isPressed || Gamepad.current.aButton.isPressed)
        {
            loadMenu();
        }
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


    private void loadMenu()
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
