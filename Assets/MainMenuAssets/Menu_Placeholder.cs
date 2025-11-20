using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Simple placeholder menu option
public class Menu_Placeholder : MonoBehaviour, ISelectable
{
    public void Select()
    {
        Debug.Log(gameObject.name); // Print gameObject when selected
    }
}
