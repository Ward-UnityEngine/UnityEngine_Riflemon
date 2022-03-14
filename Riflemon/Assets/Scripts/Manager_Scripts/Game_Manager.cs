using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{


    private static BeginConditions beginCond = null;
    
    public static void setUp(BeginConditions beginConditions)
    {
        beginCond = beginConditions;
    }

    public static void loadScene(BeginConditions beginConditions, int nextScene)
    {
        beginCond = beginConditions;
        SceneManager.LoadScene(nextScene);
    }

    public static BeginConditions loadBeginConditions()
    {
        return beginCond;
    }
    public static bool getToWorld()
    {
        if (beginCond != null)
            return !beginCond.getIsInside();
        else return true;
    }
}
