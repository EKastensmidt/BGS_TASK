using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Object/Items", order = 0)]
public class ShopItem : ScriptableObject
{
    [SerializeField] private string itemName;
    [SerializeField] private int itemPrice;
    [SerializeField] private Sprite itemImage;
    [SerializeField] private GameObject prefab;
    [SerializeField] private string crushFlavourText;
    [SerializeField] private ShopItem nextItem;

    public string ItemName { get => itemName; }
    public int ItemPrice { get => itemPrice; }
    public Sprite ItemImage { get => itemImage; }
    public GameObject Prefab { get => prefab; }
    public string CrushFlavourText { get => crushFlavourText; }
    public ShopItem NextItem { get => nextItem; }
}
