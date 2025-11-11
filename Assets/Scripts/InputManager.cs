using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    public static Action<float> OnJump;
    public static Action<Vector2> OnMove; // 🟢 new movement event

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
    }

    private void OnDisable()
    {
        actions.MouseAndKeyboard.Jump.performed -= InvokeJump;
        actions.MouseAndKeyboard.Jump.canceled -= InvokeJump;

        actions.MouseAndKeyboard.Move.performed -= InvokeMove;
        actions.MouseAndKeyboard.Move.canceled -= InvokeMove;

        actions.Disable();
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
