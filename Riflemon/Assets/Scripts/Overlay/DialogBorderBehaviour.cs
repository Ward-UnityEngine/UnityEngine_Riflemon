using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;

public class DialogBorderBehaviour : MonoBehaviour
{
    private PlayerBehaviour playerBehaviour;
    private string[] text;
    private int displayIndex = 0;

    private TextMeshProUGUI textUI;
    private Animator blinkingArrowAnim;
    private Coroutine revealingCoroutine;
    private bool coroutineRunning;
    private OverlayStarter overlayStarter;

    public float textRevealInterval;
    public float dramaticTextRevealInterval;
    private float currentTextRevealInterval;
    public int maxLenString;

    private void Awake()
    {
        textUI = GetComponentInChildren<TextMeshProUGUI>();
        blinkingArrowAnim = GetComponentInChildren<Animator>();
    }
    private void Start()
    {
        blinkingArrowAnim.SetBool("Blinking", false);
    }

    private void Update()
    {
        if (playerBehaviour.getInteractive())
        {
            if (coroutineRunning)
            {
                StopCoroutine(revealingCoroutine);
                blinkingArrowAnim.SetBool("Blinking", true);
                coroutineRunning = false;
                textUI.text = text[displayIndex];
            }
            else
            {
                if(displayIndex>=(text.Length-1))
                    end_dialog();
                else
                {
                    //display next sentence
                    displayIndex++;
                    revealingCoroutine = StartCoroutine("revealText");
                }
            }
        }
    }

    public void start_dialog(PlayerBehaviour playerBehaviour,string[] targetText,OverlayStarter overlayStarter)
    {
        Time.timeScale = 0;
        this.playerBehaviour = playerBehaviour;
        this.text = computeStringArray(targetText);
        this.overlayStarter = overlayStarter;
        textUI.text = "";
        revealingCoroutine = StartCoroutine("revealText");
    }

    private string[] computeStringArray(string[] array)
    {
        List<string> result = new List<string>(array.Length);
        for(int x = 0; x<array.Length;x++)
        {
            array[x] = array[x].Replace("\\n", "\n");
            while (array[x].Length > maxLenString)
            {
                int splitPos = findSplitPosition(array,x);
                if (splitPos == -1)
                {
                    //no split pos
                    result.Add(array[x].Substring(0, maxLenString));
                    array[x] = array[x].Remove(0, maxLenString);
                }
                else
                {
                    result.Add(array[x].Substring(0, splitPos));
                    array[x] = array[x].Remove(0, splitPos);
                }
            }
            result.Add(array[x]);
        }
        return result.ToArray();
        
    }

    private int findSplitPosition(string[] array,int x)
    {
        //split into multiple strings
        int index = maxLenString - 1;
        while ((array[x])[index] != ' ')
        {
            index--;
            if (index < 1)
            {
                //we won't be able to split based on spaces
                return -1;
            }
        }
        index++;
        return index;
    }

    private void end_dialog()
    {
        Time.timeScale = 1;
        overlayStarter.overlayActive = false;
        this.gameObject.SetActive(false);
    }

    private bool checkForCommands()
    {
        if(text[displayIndex][0] != '|') return false;
        StringBuilder stringBuilder = new StringBuilder();
        for(int x = 1;x<text[displayIndex].Length;x++)
        {
            char next = text[displayIndex][x];
            if (next == '|')
            {
                //finished
                if (stringBuilder.ToString().Contains("timedramatic"))
                {
                    currentTextRevealInterval = dramaticTextRevealInterval;
                    text[displayIndex] = text[displayIndex].Remove(0, x+1);
                    return true;
                }
            }
            stringBuilder.Append(next);
            
        }
        return false;
    }

    private IEnumerator revealText()
    {
        currentTextRevealInterval = textRevealInterval;
        checkForCommands();
        blinkingArrowAnim.SetBool("Blinking", false);
        coroutineRunning = true;
        textUI.text = "";
        for(int x = 0; x<text[displayIndex].Length;x++)
        {
            textUI.text += text[displayIndex][x];
            yield return new WaitForSecondsRealtime(currentTextRevealInterval);
        }
        coroutineRunning = false;
        blinkingArrowAnim.SetBool("Blinking", true);
       
    }
}
