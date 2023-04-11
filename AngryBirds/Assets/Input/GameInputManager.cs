using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameInputManager : MonoBehaviour
{
    public static GameInputManager SharedInsatance;

    private PlayerInputActions playerInput;
    public event EventHandler OnInteractPush;

    private void Awake()
    {
        SharedInsatance = this;

        playerInput = new PlayerInputActions();
        playerInput.player.Enable();
        playerInput.player.Interact.performed += Interact_performed;
    }

    private void OnDestroy()
    {
        playerInput.player.Interact.performed -= Interact_performed;

        playerInput.Dispose();
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractPush?.Invoke(this, EventArgs.Empty);
    }
}
