using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerStats stats;
    [SerializeField] private SpriteRenderer clothingSprite;

    protected bool isReadyToInteract = false;
    private int money = 5;
    public PlayerStats Stats { get => stats; set => stats = value; }

    public virtual void Start()
    {
        
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
