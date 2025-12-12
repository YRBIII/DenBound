using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles player jump input events
public class PlayerJump : MonoBehaviour
{
    // Subscribes to jump input events
    private void OnEnable()
    {
        InputManager.OnJump += ProcessJump;
    }

    // Unsubscribes from jump input events
    private void OnDisable()
    {
        InputManager.OnJump -= ProcessJump;
    }

    // Processes jump input values and routes them to the appropriate action
    private void ProcessJump(float value)
    {
        if (value == 1)
        {
            JumpPressed();
        }
        else if (value == 0)
        {
            JumpReleased();
        }
    }

    // Called when the jump input is pressed
    private void JumpPressed()
    {
        Debug.Log("Spacebar pressed → Player wants to jump!");
    }

    // Called when the jump input is released
    private void JumpReleased()
    {
        Debug.Log("Spacebar released → Jump ended!");
    }
}
