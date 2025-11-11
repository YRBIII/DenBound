using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    
    public static SaveManager instance;

    
    private static string _clickCount = "clickCount";


    public static int clicks;

    private void Awake()
    {
        // Check if an instance already exists
        if (instance != null && instance != this)
        {
            Destroy(gameObject); // Destroy duplicate
        }
        else
        {
            instance = this; 
            DontDestroyOnLoad(gameObject); 

            
            // If no key exists, it defaults to 0
            clicks = PlayerPrefs.GetInt(_clickCount, 0);
        }
    }

    
    public static void IncrementClicks()
    {
        clicks++;
    }

    
    public void Save()
    {
        PlayerPrefs.SetInt(_clickCount, clicks);
        PlayerPrefs.Save(); 
        Debug.Log("Saved clickCount: " + clicks); 
    }


    private void OnApplicationQuit()
    {
        Save();
    }
}
