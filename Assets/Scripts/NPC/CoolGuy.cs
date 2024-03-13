using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class CoolGuy : MonoBehaviour
{
    [SerializeField] private ShopItem startingItem;
    [SerializeField] private SpriteRenderer clothing;

    private ShopItem currentItem;

    public ShopItem CurrentItem { get => currentItem; private set => currentItem = value; }

    private bool isGameReadyToEnd = false;
    public bool IsGameReadyToEnd { get => isGameReadyToEnd; }


    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }

    private void Start()
    {
        SetStartingItem();
    }

    private void SetStartingItem()
    {
        currentItem = startingItem;
        clothing.sprite = currentItem.ItemImage;
    }

    public void ChangeItem()
    {
        currentItem = currentItem.NextItem;

        if (currentItem == null)
        {
            isGameReadyToEnd = true;
        }
        else
        {
            clothing.sprite = currentItem.ItemImage;

        }
    }
}
