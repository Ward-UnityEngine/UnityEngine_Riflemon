using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save_Manager
{

    private static int slot = 0;

    public static void set_slot(int target_slot)
    {
        slot = target_slot;
    }
    public static void save_game()
    {
        if (slot != 0)
        {
            Debug.Log("Saving the game");
        }
        else
        {
            Debug.Log("Failed to save the game");
        }
        
    }

}
