using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader: MonoBehaviour
{
    public bool goesToInside;
    public Vector2 nextDir;
    public Vector2 nextPos;
    public void loadScene(int targetScene)
    {
        Game_Manager.loadScene(new BeginConditions(nextPos,nextDir,goesToInside), targetScene);
    }
    
}
