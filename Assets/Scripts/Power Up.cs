using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private MaterialChange PowerUpType;
    public static event Action<Vector2> OnvelocityChange;
    public static event Action OnChangeGravity;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switch (PowerUpType)
            {
                case MaterialChange.OnOnlyHorizontal:
                    OnvelocityChange?.Invoke(Vector2.up);
                    break;
                case MaterialChange.OnOnlyVertical:
                    OnvelocityChange?.Invoke(Vector2.right);
                    break;
                case MaterialChange.OnLooseGravity:
                    OnChangeGravity?.Invoke();
                    break;
                default:
                    break;
            }
        }
    }
}
