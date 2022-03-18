using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignBehaviour : MonoBehaviour
{
    public string text;
    OverlayStarter overlay;

    private BoxCollider2D colliderObj;
    private PlayerBehaviour playerBehaviour;

    private void Awake()
    {
        colliderObj = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        overlay = FindObjectOfType<OverlayStarter>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerBehaviour = collision.gameObject.GetComponent<PlayerBehaviour>();

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player_tag"))
        {
            if(playerBehaviour.getInteractive() && !overlay.overlayActive)
            {
                overlay.startDialogBorder(playerBehaviour,text);
                overlay.overlayActive = true;
                colliderObj.enabled = false;
                Invoke("reEnable", 0.4f);
            }
        }
    }

    private void reEnable()
    {
        colliderObj.enabled = true;
    }
}
