using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NPCSlot : MonoBehaviour
{

    [SerializeField] private Image itemImage;
    [SerializeField] private TextMeshProUGUI itemName, itemPrice;
    [SerializeField] private Button buyButton;

    [SerializeField] private ShopItem item;

    private Player player;
    private InventorySystem inventorySystem;

    private void Start()
    {
        itemName.text = item.ItemName;
        itemPrice.text = "$" + item.ItemPrice.ToString();
        itemImage.sprite = item.ItemImage;

        player = FindObjectOfType<Player>();
        inventorySystem = FindObjectOfType<InventorySystem>();
    }

    public void BuyItem() //Button Call
    {
        if (player.GetMoney() < item.ItemPrice)
        {
            //EVENT FOR NO MONEY?
        }
        else
        {
            player.LooseMoney(item.ItemPrice);
            inventorySystem.Add(item);
            buyButton.interactable = false;
        }
    }

}
