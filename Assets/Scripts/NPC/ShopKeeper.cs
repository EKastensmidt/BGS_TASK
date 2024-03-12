using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeper : InteractableObject, IInteractable
{
    [SerializeField] private GameObject shop;
    public bool CanInteract { get; set; }
    public override void Interact()
    {
        if (!CanInteract)
            return;

        base.Interact();
        shop.SetActive(true);
    }

    public override void OnInteractionEnd()
    {
        base.OnInteractionEnd();
        shop.SetActive(false);
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
