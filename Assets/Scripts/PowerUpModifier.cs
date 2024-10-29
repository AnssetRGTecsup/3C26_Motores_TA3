using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PowerUpModifier : MonoBehaviour
{
    [SerializeField] private MaterialChange powerUpType;
    public static event Action<Vector2> OnVelocityChange;
    public static event Action OnChangeGravity;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switch (powerUpType)
            {
                case MaterialChange.OnOnlyHorizontal:
                    OnVelocityChange?.Invoke(Vector2.up);
                    break;
                case MaterialChange.OnOnlyVertical:
                    OnVelocityChange?.Invoke(Vector2.right);
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
