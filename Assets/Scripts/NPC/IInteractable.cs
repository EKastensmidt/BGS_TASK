using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public bool CanInteract { get; set; }
    public void Interact();
    public void OnInteractionEnd();
    public void OnTriggerStay2D(Collider2D collision);
}
