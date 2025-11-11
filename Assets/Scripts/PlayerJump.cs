using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private void OnEnable()
    {
        InputManager.OnJump += ProcessJump;
    }

    private void OnDisable()
    {
        InputManager.OnJump -= ProcessJump;
    }

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

    private void JumpPressed()
    {
        Debug.Log("Spacebar pressed → Player wants to jump!");
    }

    private void JumpReleased()
    {
        Debug.Log("Spacebar released → Jump ended!");
    }
}
