using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Scriptable Object/Players", order = 0)]

public class PlayerStats : ScriptableObject
{
    [SerializeField] private float speed = 4f;
    public float Speed { get => speed; set => speed = value; }
}
