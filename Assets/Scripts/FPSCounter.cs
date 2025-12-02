using UnityEngine;
using TMPro;

public class FPSCounter : MonoBehaviour
{
    public TMP_Text fpsText;
    float timer;

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
