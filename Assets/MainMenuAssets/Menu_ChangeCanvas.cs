using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_ChangeCanvas : MonoBehaviour, ISelectable
{
    [SerializeField] private Canvas canvasToChangeFrom;
    [SerializeField] private Canvas canavsToChangeTo;
    public void Select()
    {
       canavsToChangeTo.gameObject.SetActive(true);
       canvasToChangeFrom.gameObject.SetActive(false);
    }
}
