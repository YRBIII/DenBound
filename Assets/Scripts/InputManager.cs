using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    public static Action<float> OnJump;
    public static Action<Vector2> OnMove; // 🟢 new movement event
    public static Action OnMenuAction;
    public static Action OnSelect;
    public static Action OnNavigateUp;
    public static Action OnNavigateDown;

    private ThirdPerson actions;

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

    private void OnEnable()
    {
        actions.Enable();

        actions.MouseAndKeyboard.Jump.performed += InvokeJump;
        actions.MouseAndKeyboard.Jump.canceled += InvokeJump;

        actions.MouseAndKeyboard.Move.performed += InvokeMove; // 🟢 listen for movement
        actions.MouseAndKeyboard.Move.canceled += InvokeMove;

        actions.MouseAndKeyboard.MenuAction.performed += InvokeMenuAction;
        actions.MouseAndKeyboard.MenuAction.canceled += InvokeMenuAction;

        actions.MouseAndKeyboard.Select.performed += InvokeSelect;
        actions.MouseAndKeyboard.Select.canceled += InvokeSelect;
        actions.MouseAndKeyboard.NavigateUp.performed += InvokeNavigateUp;
        actions.MouseAndKeyboard.NavigateDown.performed += InvokeNavigateDown;

    }

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


        actions.Disable();
    }

    private void InvokeNavigateUp(InputAction.CallbackContext ctx)
    {
        OnNavigateUp.Invoke();
    }

    private void InvokeNavigateDown(InputAction.CallbackContext ctx)
    {
        OnNavigateDown.Invoke();
    }

    private void InvokeMenuAction(InputAction.CallbackContext ctx)
    {
        OnMenuAction.Invoke();
    }

    private void InvokeSelect(InputAction.CallbackContext ctx)
    {
        OnSelect?.Invoke();
    }
    private void InvokeJump(InputAction.CallbackContext ctx)
    {
        float value = ctx.ReadValue<float>();
        OnJump?.Invoke(value);
    }

    private void InvokeMove(InputAction.CallbackContext ctx) // 🟢 new method
    {
        Vector2 value = ctx.ReadValue<Vector2>();
        OnMove?.Invoke(value);
    }
}
