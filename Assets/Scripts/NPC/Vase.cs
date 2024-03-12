using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vase : InteractableObject, IInteractable
{
    public bool CanInteract { get; set; }
    [SerializeField] private int minMoney = 1;
    [SerializeField] private int maxMoney = 10;

    Player player;
    public override void Start()
    {
        player = FindObjectOfType<Player>();
    }

    public override void Interact()
    {
        if (!CanInteract)
            return;

        base.Interact();

        GetRandomMoneyAmount();
    }

    public override void OnInteractionEnd()
    {
        base.OnInteractionEnd();
        CanInteract = false;
    }

    public override void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            CanInteract = true;
        }
    }

    private void GetRandomMoneyAmount()
    {
        int rand = Random.Range(minMoney, maxMoney);
        player.AddMoney(rand);
    }
}
