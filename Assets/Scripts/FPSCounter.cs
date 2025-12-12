using UnityEngine;
using TMPro;

// Displays the current frames per second on the screen
public class FPSCounter : MonoBehaviour
{
    public TMP_Text fpsText;
    float timer;

    // Updates the FPS display at a fixed interval instead of every frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 0.5f)
        {
            int fps = (int)(1f / Time.unscaledDeltaTime);
            fpsText.text = "FPS: " + fps;
            timer = 0f;
        }
    }
}
