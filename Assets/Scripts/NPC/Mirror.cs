using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : InteractableObject, IInteractable
{
    [SerializeField] private GameObject equipMenu;
    [SerializeField] private GameObject itemPrefab;
    [SerializeField] List<ShopItem> clothesList;
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

        equipMenu.SetActive(true);
        CheckInventory();
    }

    public override void OnInteractionEnd()
    {
        base.OnInteractionEnd();

        DestroyItems();
        equipMenu.SetActive(false);
        CanInteract = false;
    }

    private void CheckInventory()
    {
        foreach(InventoryItem inventoryItem in inventorySystem.inventory)
        {
            GameObject obj = Instantiate(itemPrefab);
            obj.transform.SetParent(equipMenu.transform.GetChild(0), false);

            EquipmentItem equipment = obj.GetComponent<EquipmentItem>();
            equipment.SetShopItem(inventoryItem.data);
        }
    }

    public override void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            CanInteract = true;
        }
    }

    private void DestroyItems()
    {
        foreach(Transform t in equipMenu.transform.GetChild(0).transform)
        {
            Destroy(t.gameObject);
        }
    }
}
