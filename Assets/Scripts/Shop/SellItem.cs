using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SellItem : MonoBehaviour
{
    [SerializeField] private Image itemImage;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private Button sellButton;
    [SerializeField] private TextMeshProUGUI price;

    private Player player;
    private ShopItem shopItem;
    private InventorySystem inventorySystem;
    private InventoryUIManager inventoryUIManager;
    private void Start()
    {
        player = FindObjectOfType<Player>();
        inventorySystem = FindObjectOfType<InventorySystem>();
        inventoryUIManager = FindObjectOfType<InventoryUIManager>();
    }

    public void SellButton()
    {
        if (shopItem == null)
            return;

        player.AddMoney(shopItem.ItemPrice / 2);
        sellButton.interactable = false;

        player.TryRemoveClothing(shopItem);
        RemoveItemFromInventory(shopItem);

        inventoryUIManager.OnUpdateInventory();
    }

    public void SetShopItem(ShopItem item)
    {
        shopItem = item;
        itemImage.sprite = item.ItemImage;
        itemName.text = item.ItemName;
        price.text = "$" + (item.ItemPrice / 2).ToString();
    }

    public void RemoveItemFromInventory(ShopItem item)
    {
        for (int i = 0; i < inventorySystem.inventory.Count; i++) 
        {
            if (inventorySystem.inventory[i].data.ItemName == item.ItemName) 
            {
                inventorySystem.inventory.RemoveAt(i);
            }
        }
    }
}
