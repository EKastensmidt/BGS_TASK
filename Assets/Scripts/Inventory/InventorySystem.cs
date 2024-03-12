using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public static Action OnUpdateInventory;

    private Dictionary<ShopItem, InventoryItem> itemDictionary;
    public List<InventoryItem> inventory { get; private set; }

    private void Awake()
    {
        inventory = new List<InventoryItem>();
        itemDictionary = new Dictionary<ShopItem, InventoryItem>();
    }

    public void Add(ShopItem referenceData)
    {
        if (itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            value.AddToStack();
        }
        else
        {
            InventoryItem newItem = new InventoryItem(referenceData);
            inventory.Add(newItem);
            itemDictionary.Add(referenceData, newItem);
        }
        OnUpdateInventory?.Invoke();
    }

    //public void Remove(ShopItem referenceData)
    //{
    //    if(itemDictionary.TryGetValue(referenceData,out InventoryItem value))
    //    {
    //        value.RemoveFromStack();
    //        if(value.stackSize == 0)
    //        {
    //            inventory.Remove(value);
    //            itemDictionary.Remove(referenceData);
    //        }
    //    }
    //    OnUpdateInventory?.Invoke();
    //}

    //public InventoryItem Get(ShopItem referenceData)
    //{
    //    if(itemDictionary.TryGetValue(referenceData, out InventoryItem value))
    //    {
    //        return value;
    //    }
    //    return null;
    //}
}
