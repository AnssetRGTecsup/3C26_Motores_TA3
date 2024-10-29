using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PowerUpsModifier : MonoBehaviour
{
    [SerializeField] private MaterialChange powerUpType;
    public static event Action<Vector2> onVelocityChange;
    public static event Action onGravityChange;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switch (powerUpType)
            {
                case MaterialChange.OnOnlyHorizontal:
                    onVelocityChange?.Invoke(Vector2.up);
                    break;
                case MaterialChange.OnOnlyVertical:
                    onVelocityChange?.Invoke(Vector2.right);
                    break;
                case MaterialChange.OnLooseGravity:
                    onGravityChange?.Invoke();
                    break;
                default:
                    break;

            }
        }
    }
}
