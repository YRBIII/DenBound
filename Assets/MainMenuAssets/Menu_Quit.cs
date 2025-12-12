using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

// Handles the Quit option in the menu
public class Menu_Quit : MonoBehaviour, ISelectable
{
    // Quits the game when this menu option is selected
    public void Select()
    {
#if UNITY_EDITOR
        // Stops Play mode when testing inside the Unity Editor
        Debug.Log("Quit selected");
        EditorApplication.isPlaying = false;
#else
        // Quits the application in a built version of the game
        Application.Quit();
#endif
    }
}
