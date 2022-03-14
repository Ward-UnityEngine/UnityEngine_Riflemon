using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadWorldManager : MonoBehaviour
{
    private static Animator animator;
    private static PlayerBehaviour playerBehaviour;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerBehaviour = FindObjectOfType<PlayerBehaviour>();
    }

    private void Start()
    {
        if(Game_Manager.getToWorld())
        {
            animator.SetBool("toWorld", true);
        }
        else
        {
            animator.SetBool("toInterior", true);
        }
    }




    public void loadIsDone(string bool_name)
    {
        Debug.Log(bool_name);
        animator.SetBool(bool_name, false);
        enablePlayer();
    }

    private static void enablePlayer()
    {
        playerBehaviour.enableInput();
    }
}
