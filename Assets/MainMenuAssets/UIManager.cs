using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private uint selectedOption = 0;
    [SerializeField] private GameObject[] options;
    private Menu_ChangeCanvas changeCanvas;

    private void OnEnable()
    {
        InputManager.OnMenuAction += Back;
        InputManager.OnSelect += Select;
    }

    private void Awake()
    {
        if (GetComponent<Menu_ChangeCanvas>())
        {
            changeCanvas = GetComponent<Menu_ChangeCanvas>();
        }
        ChangeTextColor(true);
    }

    private void ChangeTextColor(bool state)
    {
        options[selectedOption].GetComponent<TextMeshProUGUI>().color = Color.green;
    }


    private void Select()
    {
        options[selectedOption].GetComponent<ISelectable>().Select();
    }

    private void Back()
    {
            changeCanvas?.Select();
    }

    private void OnDisable()
    {
        InputManager.OnMenuAction -= Back;
        InputManager.OnSelect -= Select;
    }

}
