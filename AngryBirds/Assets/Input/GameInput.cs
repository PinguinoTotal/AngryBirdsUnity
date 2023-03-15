using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using System;

public class GameInput : MonoBehaviour
{
    private PlayerInputActions playerInput;
    public event EventHandler OnInteractPush;

    private void Awake()
    {
        playerInput = new PlayerInputActions();
        playerInput.player.Enable();
        playerInput.player.Interact.performed += Interact_performed;
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractPush?.Invoke(this,EventArgs.Empty);
    }
}
