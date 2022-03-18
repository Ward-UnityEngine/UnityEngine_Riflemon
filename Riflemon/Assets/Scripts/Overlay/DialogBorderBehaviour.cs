using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogBorderBehaviour : MonoBehaviour
{
    private PlayerBehaviour playerBehaviour;
    string text = string.Empty;

    private TextMeshProUGUI textUI;
    private Coroutine revealingCoroutine;
    private bool coroutineRunning;
    private OverlayStarter overlayStarter;

    public float textRevealInterval;

    private void Awake()
    {
        textUI = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (playerBehaviour.getInteractive())
        {
            if (coroutineRunning)
            {
                StopCoroutine(revealingCoroutine);
                coroutineRunning = false;
                textUI.text = text;
            }
            else
            {
                end_dialog();
            }
        }
    }

    public void start_dialog(PlayerBehaviour playerBehaviour,string targetText,OverlayStarter overlayStarter)
    {
        Time.timeScale = 0;
        this.playerBehaviour = playerBehaviour;
        this.text = targetText.Replace("\\n", "\n"); ;
        this.overlayStarter = overlayStarter;
        textUI.text = "";
        revealingCoroutine = StartCoroutine("revealText");
    }

    private void end_dialog()
    {
        Time.timeScale = 1;
        overlayStarter.overlayActive = false;
        this.gameObject.SetActive(false);
    }

    private IEnumerator revealText()
    {
        coroutineRunning = true;
        for(int x = 0; x<text.Length;x++)
        {
            textUI.text += text[x];
            yield return new WaitForSecondsRealtime(textRevealInterval);
        }
        coroutineRunning = false;
       
    }
}
