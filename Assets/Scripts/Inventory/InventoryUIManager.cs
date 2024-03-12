using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Tilemaps;
using UnityEngine;

public class InventoryUIManager : MonoBehaviour
{
    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private TextMeshProUGUI money;

    private InventorySystem inventorySystem;
    private void Awake()
    {
        InventorySystem.OnUpdateInventory += OnUpdateInventory;
        Player.OnMoneyChange += UpdateMoney;
    }
    private void OnDestroy()
    {
        InventorySystem.OnUpdateInventory -= OnUpdateInventory;
        Player.OnMoneyChange -= UpdateMoney;
    }

    private void Start()
    {
        inventorySystem = FindObjectOfType<InventorySystem>();
    }

    public void OnUpdateInventory()
    {
        foreach (Transform t in transform)
        {
            Destroy(t.gameObject);
        }

        DrawInventory();
    }

    public void UpdateMoney(int value)
    {
        money.text = "$ " + value.ToString();
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
