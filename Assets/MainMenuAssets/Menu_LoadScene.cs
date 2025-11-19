using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Loadscene : MonoBehaviour, ISelectable
{
    [SerializeField] string sceneName;
    public void Select()
    {
        SceneManager.LoadScene(sceneName);
    }
}
