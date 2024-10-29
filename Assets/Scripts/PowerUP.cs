using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PowerUP : MonoBehaviour
{
    [SerializeField] private MaterialChange powerUPtype;

    public static event Action<Vector2> OnVelocityChange;
    public static event Action OnChangeGravity;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switch (powerUPtype)
            {
                case MaterialChange.OnOnlyHorizontal:
                    //solo horizontal
                    OnVelocityChange?.Invoke(Vector2.up);
                    break;
                case MaterialChange.OnOnlyVertical:
                    // solo vertical
                    OnVelocityChange?.Invoke(Vector2.right);

                    break;
                case MaterialChange.OnLooseGravity:
                    //quita gravedad
                    OnChangeGravity?.Invoke();
                    break;
                default:
                    break;

            }
        }
    }
}
