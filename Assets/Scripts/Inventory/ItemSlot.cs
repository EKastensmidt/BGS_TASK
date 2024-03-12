using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] private Image icon;

    public void Set(InventoryItem item) 
    {
        icon.sprite = item.data.ItemImage;
    }
}
