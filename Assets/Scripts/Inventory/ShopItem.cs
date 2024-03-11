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

    public string ItemName { get => itemName; }
    public int ItemPrice { get => itemPrice; }
    public Sprite ItemImage { get => itemImage; }
    public GameObject Prefab { get => prefab; }
}
