using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class InventoryUIManager : MonoBehaviour
{
    [SerializeField] private GameObject slotPrefab;
    private InventorySystem inventorySystem;
    private void Awake()
    {
        InventorySystem.OnUpdateInventory += OnUpdateInventory;
    }
    private void OnDestroy()
    {
        InventorySystem.OnUpdateInventory -= OnUpdateInventory;
    }

    private void Start()
    {
        inventorySystem = FindObjectOfType<InventorySystem>();
    }

    private void OnUpdateInventory()
    {
        foreach (Transform t in transform)
        {
            Destroy(t.gameObject);
        }

        DrawInventory();
    }
    private void DrawInventory()
    {
        foreach (InventoryItem item in inventorySystem.inventory)
        {
            AddInventorySlot(item);
        }
    }

    private void AddInventorySlot(InventoryItem item)
    {
        GameObject obj = Instantiate(slotPrefab);
        obj.transform.SetParent(transform, false);

        ItemSlot slot = obj.GetComponent<ItemSlot>();
        slot.Set(item);
    }
}
