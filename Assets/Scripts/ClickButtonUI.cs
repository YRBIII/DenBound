using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClickButtonUI : MonoBehaviour
{
    private TextMeshProUGUI buttonText;

    private void Start()
    {
        // Find the TextMeshProUGUI label in the Button's children
        buttonText = GetComponentInChildren<TextMeshProUGUI>();
        if (buttonText == null)
        {
            Debug.LogError("ClickButtonUI: No TextMeshProUGUI found in children. Add a Text - TextMeshPro child or assign manually.");
            return;
        }

        // A warning if SaveManager isn't present
        if (SaveManager.instance == null)
        {
            Debug.LogWarning("SaveManager instance not found. clicks will be default (0) until you add SaveManager to the scene.");
        }

        // Set the initial text from the singleton's cached value
        buttonText.text = SaveManager.clicks.ToString();
    }

    
    public void OnButtonClick()
    {
        
        SaveManager.IncrementClicks();

        
        if (buttonText != null)
            buttonText.text = SaveManager.clicks.ToString();
    }
}

