using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Crush : InteractableObject, IInteractable
{
    public static Action OnGameEnd;

    [SerializeField] private TextMeshProUGUI dialog;

    private CoolGuy coolGuy;

    public bool CanInteract { get; set; }

    public override void Start()
    {
        coolGuy = FindObjectOfType<CoolGuy>();
    }

    public override void Interact()
    {
        if (!CanInteract)
        {
            return;
        }

        base.Interact();

        if (coolGuy.IsGameReadyToEnd)
        {
            OnGameEnd?.Invoke();
        }
        else
        {
            dialog.text = coolGuy.CurrentItem.CrushFlavourText;
        }
    }

    public override void OnInteractionEnd()
    {
        base.OnInteractionEnd();

        dialog.text = "";
        CanInteract = false;
    }

    public override void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            CanInteract = true;
        }
    }
}
