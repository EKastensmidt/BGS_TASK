using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Action<int> OnMoneyChange;

    [SerializeField] private PlayerStats stats;
    [SerializeField] private SpriteRenderer clothingSprite;

    protected bool isReadyToInteract = false;
    private int money;
    public PlayerStats Stats { get => stats; set => stats = value; }

    public ShopItem currentItem;
    private CoolGuy coolGuy;

    protected bool canInteract = true;

    public virtual void OnEnable()
    {
        //NPCSlot.OnItemPurchase += CheckIfRightItem;
    }

    public virtual void OnDisable()
    {
        //NPCSlot.OnItemPurchase -= CheckIfRightItem;
    }

    public virtual void Start()
    {
        money = stats.StartingMoney;
        OnMoneyChange?.Invoke(money);

        coolGuy = FindObjectOfType<CoolGuy>();
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

        CheckIfRightItem(item);
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

        OnMoneyChange?.Invoke(money);
    }

    public void LooseMoney(int value)
    {
        money -= value;
        if(money <= 0)
        {
            money = 0;
        }

        OnMoneyChange?.Invoke(money);
    }

    public int GetMoney()
    {
        return money;
    }

    private void CheckIfRightItem(ShopItem item)
    {
        if(coolGuy.CurrentItem.ItemName == item.ItemName)
        {
            coolGuy.ChangeItem();
        }   
    }

    public void DisableInteraction()
    {
        canInteract = false;
    }
}
