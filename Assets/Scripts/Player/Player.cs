using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerStats stats;
    [SerializeField] private SpriteRenderer clothingSprite;

    protected bool isReadyToInteract = false;
    private int money;
    public PlayerStats Stats { get => stats; set => stats = value; }

    public ShopItem currentItem;

    public virtual void Start()
    {
        money = stats.StartingMoney;
    }

    public virtual void Update()
    {
        
    }

    public void SetInteractability(bool value)
    {
        isReadyToInteract = value;
    }

    public void AddClothing(ShopItem item)
    {
        clothingSprite.sprite = item.ItemImage;
        currentItem = item;
    }

    public void TryRemoveClothing(ShopItem item)
    {
        if (currentItem == null || item.ItemName != currentItem.ItemName)
        {
            return;
        }

        clothingSprite.sprite = null;
        currentItem = null;
    }

    public void AddMoney(int value)
    {
        money += value;
    }

    public void LooseMoney(int value)
    {
        money -= value;
        if(money <= 0)
        {
            money = 0;
        }
    }

    public int GetMoney()
    {
        return money;
    }
}
