using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class powerupmodifique : MonoBehaviour
{
    [SerializeField] private MaterialChange powerUptype;

    public static event Action<Vector2> OnVelocityChange;
    public static event Action OnChangeGravity;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            switch (powerUptype) {
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
