using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PowerUpModifier : MonoBehaviour
{
    [SerializeField] private MaterialChange powerUpType;

    public static event Action<Vector2> OnVelocityChangue;
    public static event Action OnChangueGravity;
    private void OnTriggerEnter(Collider other)
    {
        if( other != null && other.gameObject.tag == "Player")
        {
            switch (powerUpType)
            {
                case MaterialChange.OnOnlyHorizontal
                :
                    OnVelocityChangue?.Invoke(Vector2.up);
                    break;
                case MaterialChange.OnOnlyVertical:
                    OnVelocityChangue?.Invoke(Vector2.right);
                    break;
                case MaterialChange.OnLooseGravity:
                    OnChangueGravity?.Invoke();
                    break;
              
                default:
                    break;
            }
        }
    }
}
