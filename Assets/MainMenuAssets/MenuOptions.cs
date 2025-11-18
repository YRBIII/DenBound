using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
[RequireComponent (typeof(Collider))]
public class MenuOptions : MonoBehaviour
{
    [SerializeField] private Color hoverColor;
    [SerializeField] private Color originalColor;
    private TextMeshProUGUI _text;

    private void Awake()
    {
       _text = GetComponent<TextMeshProUGUI>();

    }
    private void OnMouseEnter()
    {
        _text.color = hoverColor;
    }

    private void OnMouseExit()
    {
       _text.color= originalColor;
    }
}
