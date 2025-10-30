using System;
using UnityEngine;

public class powerup : MonoBehaviour
{
    [SerializeField] private MaterialChange poweType;
    public static event Action<MaterialChange> Oncollision;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            Oncollision?.Invoke(poweType);
        }
    }
}
