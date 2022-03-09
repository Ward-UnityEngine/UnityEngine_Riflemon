using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KeyListener : MonoBehaviour
{
    public GameObject[] startObjects;
    public GameObject[]  menuObjects;

    private void Start()
    {
        foreach (GameObject o in startObjects)
        {
            o.SetActive(true);
        }
        foreach (GameObject o2 in menuObjects)
        {
            o2.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            loadMenu();
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
