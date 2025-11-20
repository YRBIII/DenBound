using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Loads a scene when selected
public class Menu_Loadscene : MonoBehaviour, ISelectable
{
    [SerializeField] string sceneName; // Scene to load

    public void Select()
    {
        SceneManager.LoadScene(sceneName); // Load scene
    }
}
