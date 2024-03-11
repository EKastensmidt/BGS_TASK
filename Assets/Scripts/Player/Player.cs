using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerStats stats;
    protected bool isReadyToInteract = false;
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
}
