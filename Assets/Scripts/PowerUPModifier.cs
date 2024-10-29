using UnityEngine;
using System;
public class PowerUPModifier : MonoBehaviour
{
    [SerializeField] private MaterialChange powerUpTyper;
    //+1
    static public event Action<Vector2> OnVelocityChange;
    static public event Action OnChangeGravity;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switch (powerUpTyper)
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
