using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    [SerializeField] private GameObject spriteIcon;

    private void OnEnable()
    {
        PlayerController.OnPlayerInteract += Interact;
    }

    private void OnDisable()
    {
        PlayerController.OnPlayerInteract -= Interact;
    }

    public virtual void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            spriteIcon.SetActive(false);
            player.SetInteractability(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            spriteIcon.SetActive(true);
            player.SetInteractability(false);
            OnInteractionEnd();
        }
    }

    public virtual void Interact()
    {
        
    }

    public virtual void OnInteractionEnd()
    {

    }

    public virtual void OnTriggerStay2D(Collider2D collision)
    {
        
    }
}
