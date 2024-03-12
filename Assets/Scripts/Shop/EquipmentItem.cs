using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentItem : MonoBehaviour
{
    [SerializeField] private Image itemImage;
    [SerializeField] private TextMeshProUGUI itemName;

    private Player player;
    private ShopItem shopItem;

    private void Start()
    {
        player = FindObjectOfType<Player>();  
    }

    public void EquipButton()
    {
        if (shopItem == null)
            return;

        player.AddClothing(shopItem);
    }

    public void SetShopItem(ShopItem item)
    {
        shopItem = item;
        itemImage.sprite = item.ItemImage;
        itemName.text = item.ItemName;
    }
}
