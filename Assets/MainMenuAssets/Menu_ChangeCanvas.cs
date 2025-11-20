using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Switches between two canvases
public class Menu_ChangeCanvas : MonoBehaviour, ISelectable
{
    [SerializeField] private Canvas canvasToChangeFrom; // Canvas to hide
    [SerializeField] private Canvas canavsToChangeTo;  // Canvas to show

    public void Select()
    {
        canavsToChangeTo.gameObject.SetActive(true);  // Show new canvas
        canvasToChangeFrom.gameObject.SetActive(false); // Hide old canvas
    }
}