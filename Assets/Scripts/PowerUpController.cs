using System;
using System.Collections;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    // Evento que se disparará cuando ocurra la colisión con el jugador
    public static event Action<MaterialChange> OnMaterialChangeTriggered;

    // Tipo de material que este PowerUp representará
    [SerializeField] private MaterialChange materialChangeType = MaterialChange.Normal;

    // Detecta colisiones con objetos que tengan el tag "Player"
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Dispara el evento con el tipo correspondiente
            OnMaterialChangeTriggered?.Invoke(materialChangeType);
        }
    }
}