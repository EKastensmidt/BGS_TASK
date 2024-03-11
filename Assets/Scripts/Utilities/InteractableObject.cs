using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    private bool isInRange = false;

    private void OnEnable()
    {
        PlayerController.OnPlayerInteract += Interact;
    }

    private void OnDisable()
    {
        PlayerController.OnPlayerInteract -= Interact;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            player.SetInteractability(true);
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            player.SetInteractability(false);
            isInRange = false;
        }
    }

    private void Interact()
    {
        if (isInRange)
        {
            
        }
    }
}
