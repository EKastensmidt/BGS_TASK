using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceGameNPC : InteractableObject, IInteractable
{
    [SerializeField] private GameObject diceGame;
    public bool CanInteract { get; set; }

    public override void Start()
    {
        base.Start();
    }

    public override void Interact()
    {
        if (!CanInteract)
        {
            return;
        }

        base.Interact();

        diceGame.SetActive(true);
    }

    public override void OnInteractionEnd()
    {
        base.OnInteractionEnd();

        diceGame.SetActive(false);
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
