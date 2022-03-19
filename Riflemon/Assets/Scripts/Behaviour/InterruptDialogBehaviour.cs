using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterruptDialogBehaviour : MonoBehaviour
{
    public string[] text;
    OverlayStarter overlayStarter;

    private PlayerBehaviour playerBehaviour;

    private void Start()
    {
        overlayStarter = FindObjectOfType<OverlayStarter>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player_tag"))
        {
            playerBehaviour = collision.gameObject.GetComponent<PlayerBehaviour>();
            overlayStarter.startDialogBorder(playerBehaviour, text);
            GameObject.Destroy(this.gameObject);
        }
    }
}
