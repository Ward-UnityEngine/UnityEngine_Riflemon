using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlayStarter : MonoBehaviour
{
    public GameObject dialogBorderObj;
    public bool overlayActive;

    public void startDialogBorder(PlayerBehaviour player,string[] text)
    {
        if (text == null || text.Length == 0) return;
        if (text[0] == "" || text[0] == null) return;
        DialogBorderBehaviour dialogBorder = dialogBorderObj.GetComponent<DialogBorderBehaviour>();
        dialogBorderObj.SetActive(true);
        dialogBorder.start_dialog(player, text, this);
        overlayActive = true;
    }

    
}
