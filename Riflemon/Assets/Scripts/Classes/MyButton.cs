using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MyButton: MonoBehaviour
{
    private Color standard_C = new Color32(241, 231, 17,255);
    private Color highlighted_C = new Color32(217, 116, 17,255);
    public Button button;
    private TextMeshProUGUI text;

    private void Awake()
    {
        button = GetComponent<Button>();
        text = GetComponentInChildren<TextMeshProUGUI>();
        highlight(false);
        
    }

    public void highlight(bool highlighted)
    {
        if (highlighted)
        {
            text.color = highlighted_C;
        }
        else
        {
            text.color = standard_C;
        }
    }

    public void setOnClick(UnityEngine.UI.Button.ButtonClickedEvent clickedEvent)
    {
        button.onClick = clickedEvent;
    }
    public void click()
    {
        button.onClick.Invoke();
    }
    
}
