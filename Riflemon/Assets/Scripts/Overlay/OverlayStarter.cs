using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlayStarter : MonoBehaviour
{
    public GameObject dialogBorderObj;
    public bool overlayActive;


    public void startDialogBorder(PlayerBehaviour player,string targetText)
    {
        DialogBorderBehaviour dialogBorder = dialogBorderObj.GetComponent<DialogBorderBehaviour>();
        dialogBorderObj.SetActive(true);
        dialogBorder.start_dialog(player,targetText,this);
        overlayActive = true;
    }
}
