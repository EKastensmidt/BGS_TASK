using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : Player
{
    private Vector3 movement;
    private PlayerControls playerControls;

    public static Action OnPlayerInteract;

    public Vector3 Movement { get => movement; }

    public override void OnEnable()
    {
        base.OnEnable();
        playerControls.Enable();
    }

    public override void OnDisable()
    {
        base.OnDisable();
        playerControls.Disable();

    }

    private void Awake()
    {
        playerControls = new PlayerControls();

        playerControls.Gameplay.Move.performed += ReadMoveInput;
        playerControls.Gameplay.Move.canceled += ReadMoveInput;

        playerControls.Gameplay.Interact.performed += Interact;
        playerControls.Gameplay.Interact.canceled += Interact;

    }
    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();

        MovePlayer();
    }

    private void MovePlayer()
    {
        transform.position += movement * Stats.Speed * Time.deltaTime;
    }

    private void ReadMoveInput(InputAction.CallbackContext context)
    {
        var playerInput = context.ReadValue<Vector2>();
        movement.x = playerInput.x;
        movement.y = playerInput.y;
    }

    private void Interact(InputAction.CallbackContext context)
    {
        if (context.ReadValue<float>() == 1 && isReadyToInteract)
        {
            OnPlayerInteract?.Invoke();
        }
    }
}
