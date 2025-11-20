using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor; // Needed to stop Play mode when testing in the Editor
#endif

// This class handles the Quit menu option and implements ISelectable
public class Menu_Quit : MonoBehaviour, ISelectable
{
    public void Select()
    {
#if UNITY_EDITOR
        // In the Unity Editor, stops Play mode
        Debug.Log("Quit selected, stopping Play mode in Editor");
        EditorApplication.isPlaying = false; // Stop Play mode
#else
        Application.Quit(); 
#endif
    }
}
