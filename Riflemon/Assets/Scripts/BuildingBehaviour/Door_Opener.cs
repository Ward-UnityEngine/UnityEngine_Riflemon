using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door_Opener : MonoBehaviour
{
    public int targetSceneIndex;
    private PlayerBehaviour playerBehaviour;


    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player_tag") )
        {
            playerBehaviour = collision.GetComponent<PlayerBehaviour>();
            if(playerBehaviour.goingUp)
                SceneManager.LoadScene(targetSceneIndex);
        }
    }
}
