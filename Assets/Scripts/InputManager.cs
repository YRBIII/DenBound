using System;
using UnityEngine;
using UnityEngine.InputSystem;

// Manages all player input and sends it out as events other scripts can listen to
public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    public static Action<float> OnJump;
    public static Action<Vector2> onMouseDelta;
    public static Action<Vector2> OnMove;
    public static Action OnMenuAction;
    public static Action OnSelect;
    public static Action OnNavigateUp;
    public static Action OnNavigateDown;

    private ThirdPerson actions;

    // Makes sure there is only one InputManager and sets up input actions
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        actions = new ThirdPerson();
    }

    // Turns on input and connects input actions to event methods
    private void OnEnable()
    {
        actions.Enable();

        actions.MouseAndKeyboard.Jump.performed += InvokeJump;
        actions.MouseAndKeyboard.Jump.canceled += InvokeJump;

        actions.MouseAndKeyboard.Move.performed += InvokeMove;
        actions.MouseAndKeyboard.Move.canceled += InvokeMove;

        actions.MouseAndKeyboard.MenuAction.performed += InvokeMenuAction;
        actions.MouseAndKeyboard.MenuAction.canceled += InvokeMenuAction;

        actions.MouseAndKeyboard.Select.performed += InvokeSelect;
        actions.MouseAndKeyboard.Select.canceled += InvokeSelect;

        actions.MouseAndKeyboard.NavigateUp.performed += InvokeNavigateUp;
        actions.MouseAndKeyboard.NavigateDown.performed += InvokeNavigateDown;

        actions.MouseAndKeyboard.MouseDelta.performed += InvokeMouseDelta;
        actions.MouseAndKeyboard.MouseDelta.canceled += InvokeMouseDelta;
    }

    // Turns off input and disconnects all callbacks
    private void OnDisable()
    {
        actions.MouseAndKeyboard.Jump.performed -= InvokeJump;
        actions.MouseAndKeyboard.Jump.canceled -= InvokeJump;

        actions.MouseAndKeyboard.Move.performed -= InvokeMove;
        actions.MouseAndKeyboard.Move.canceled -= InvokeMove;

        actions.MouseAndKeyboard.MenuAction.performed -= InvokeMenuAction;
        actions.MouseAndKeyboard.MenuAction.canceled -= InvokeMenuAction;

        actions.MouseAndKeyboard.Select.performed -= InvokeSelect;
        actions.MouseAndKeyboard.Select.canceled -= InvokeSelect;

        actions.MouseAndKeyboard.NavigateUp.performed -= InvokeNavigateUp;
        actions.MouseAndKeyboard.NavigateDown.performed -= InvokeNavigateDown;

        actions.MouseAndKeyboard.MouseDelta.performed -= InvokeMouseDelta;
        actions.MouseAndKeyboard.MouseDelta.canceled -= InvokeMouseDelta;

        actions.Disable();
    }

    // Sends mouse movement data to anything listening
    private void InvokeMouseDelta(InputAction.CallbackContext ctx)
    {
        onMouseDelta?.Invoke(ctx.ReadValue<Vector2>());
    }

    // Triggers menu navigation upward
    private void InvokeNavigateUp(InputAction.CallbackContext ctx)
    {
        OnNavigateUp?.Invoke();
    }

    // Triggers menu navigation downward
    private void InvokeNavigateDown(InputAction.CallbackContext ctx)
    {
        OnNavigateDown?.Invoke();
    }

    // Triggers menu back / cancel action
    private void InvokeMenuAction(InputAction.CallbackContext ctx)
    {
        OnMenuAction?.Invoke();
    }

    // Triggers menu selection / confirm action
    private void InvokeSelect(InputAction.CallbackContext ctx)
    {
        OnSelect?.Invoke();
    }

    // Sends jump input with press or release value
    private void InvokeJump(InputAction.CallbackContext ctx)
    {
        float value = ctx.ReadValue<float>();
        OnJump?.Invoke(value);
    }

    // Sends movement input as a direction vector
    private void InvokeMove(InputAction.CallbackContext ctx)
    {
        Vector2 value = ctx.ReadValue<Vector2>();
        OnMove?.Invoke(value);
    }
}
