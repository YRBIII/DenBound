using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Manages saving and loading game data across scenes
public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;

    private static string _clickCount = "clickCount";

    public static int clicks;

    // Ensures a single instance and loads saved data
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            clicks = PlayerPrefs.GetInt(_clickCount, 0);
        }
    }

    // Increments the stored click counter
    public static void IncrementClicks()
    {
        clicks++;
    }

    // Saves current data to PlayerPrefs
    public void Save()
    {
        PlayerPrefs.SetInt(_clickCount, clicks);
        PlayerPrefs.Save();
        Debug.Log("Saved clickCount: " + clicks);
    }

    // Automatically saves data when the application exits
    private void OnApplicationQuit()
    {
        Save();
    }
}
