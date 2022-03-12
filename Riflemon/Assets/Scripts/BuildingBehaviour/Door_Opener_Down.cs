using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door_Opener_Down : MonoBehaviour
{
    public int targetSceneIndex;
    private PlayerBehaviour playerBehaviour;


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player_tag"))
        {
            playerBehaviour = collision.GetComponent<PlayerBehaviour>();
            if (playerBehaviour.goingDown)
                SceneManager.LoadScene(targetSceneIndex);
        }
    }
}
