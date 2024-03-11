using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraTrigger : MonoBehaviour
{
    public static Action<Transform> OnEnter;
    [SerializeField] private Transform previous;
    [SerializeField] private Transform next;
    private bool hasEnteredRoom = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            if (!hasEnteredRoom)
            {
                OnEnter?.Invoke(next);
                hasEnteredRoom = true;
            }
            else
            {
                OnEnter(previous);
                hasEnteredRoom = false;
            }
        }
    }
}
