using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Placeholder : MonoBehaviour, ISelectable
{
    public void Select()
    {
        Debug.Log(gameObject.name);
    }
}
