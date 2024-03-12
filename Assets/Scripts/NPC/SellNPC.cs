using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellNPC : InteractableObject, IInteractable
{
    [SerializeField] private GameObject SellMenu;
    [SerializeField] private GameObject itemPrefab;
    private InventorySystem inventorySystem;

    public bool CanInteract { get; set; }


    public override void Start()
    {
        base.Start();
        inventorySystem = FindObjectOfType<InventorySystem>();
    }

    public override void Interact()
    {
        if (!CanInteract)
            return;

        base.Interact();

        SellMenu.SetActive(true);
        CheckInventory();
    }

    public override void OnInteractionEnd()
    {
        base.OnInteractionEnd();

        DestroyItems();
        SellMenu.SetActive(false);
        CanInteract = false;
    }

    public override void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            CanInteract = true;
        }
    }

    private void CheckInventory()
    {
        foreach (InventoryItem inventoryItem in inventorySystem.inventory)
        {
            GameObject obj = Instantiate(itemPrefab);
            obj.transform.SetParent(SellMenu.transform.GetChild(0), false);

            SellItem equipment = obj.GetComponent<SellItem>();
            equipment.SetShopItem(inventoryItem.data);
        }
    }

    private void DestroyItems()
    {
        foreach (Transform t in SellMenu.transform.GetChild(0).transform)
        {
            Destroy(t.gameObject);
        }
    }
}
