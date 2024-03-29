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
    public static Action OnPlayerPause;

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

        playerControls.Gameplay.Pause.performed += Pause;
        playerControls.Gameplay.Pause.canceled += Pause;

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
        if (!canInteract)
        {
            return;
        }

        var playerInput = context.ReadValue<Vector2>();
        movement.x = playerInput.x;
        movement.y = playerInput.y;

        if(movement != Vector3.zero)
        {
            animator.SetBool("isMoving",true);
            animator.SetFloat("X", movement.x);
            animator.SetFloat("Y", movement.y);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }

    private void Interact(InputAction.CallbackContext context)
    {
        if (!canInteract)
        {
            return;
        }

        if (context.ReadValue<float>() == 1 && isReadyToInteract)
        {
            OnPlayerInteract?.Invoke();
        }
    }

    private void Pause(InputAction.CallbackContext context)
    {
        if (!canInteract)
        {
            return;
        }

        if (context.ReadValue<float>() == 1)
        {
            OnPlayerPause?.Invoke();
        }
    }
}
