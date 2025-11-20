using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private uint selectedOption = 0; // Currently highlighted menu option
    [SerializeField] private GameObject[] options; // Menu option UI elements
    private Menu_ChangeCanvas changeCanvas; // Reference to canvas switching script

    private void OnEnable()
    {
        // Subscribe to input events
        InputManager.OnNavigateDown += NavigateDown;
        InputManager.OnNavigateUp += NavigateUp;
        InputManager.OnSelect += Select;
        InputManager.OnMenuAction += Back;
    }

    private void Awake()
    {
        // Cache canvas switcher if present
        if (GetComponent<Menu_ChangeCanvas>())
        {
            changeCanvas = GetComponent<Menu_ChangeCanvas>();
        }

        // Highlight the first option
        options[selectedOption].GetComponent<TextMeshProUGUI>().color = Color.green;
    }

    // Change the selected menu option
    private void ChangeOption(int direction)
    {
        // Remove highlight from current option
        options[selectedOption].GetComponent<TextMeshProUGUI>().color = Color.white;

        // Move index and wrap around if needed
        selectedOption = (uint)((selectedOption + direction + options.Length) % options.Length);

        // Highlight new option
        options[selectedOption].GetComponent<TextMeshProUGUI>().color = Color.green;
    }

    // Navigate menu up
    private void NavigateUp() => ChangeOption(-1);

    // Navigate menu down
    private void NavigateDown() => ChangeOption(1);

    // Call Select() on the currently highlighted option
    private void Select()
    {
        options[selectedOption].GetComponent<ISelectable>().Select();
    }

    // Go back using canvas switcher if available
    private void Back()
    {
        changeCanvas?.Select();
    }

    private void OnDisable()
    {
        // Unsubscribe from input events
        InputManager.OnNavigateDown -= NavigateDown;
        InputManager.OnNavigateUp -= NavigateUp;
        InputManager.OnSelect -= Select;
        InputManager.OnMenuAction -= Back;
    }
}
