using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameDataScriptableObject currentData;

    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity = new Vector3(currentData.xAcceleration,currentData.gravity + currentData.yAcceleration,0f);

        Debug.Log(currentData.xAcceleration);
        Debug.Log(currentData.yAcceleration);
    }
    private void OnEnable()
    {
        BallController.OnGravityzero += Gravityzero;
    }
    private void OnDisable()
    {
        BallController.OnGravityzero -= Gravityzero;
    }
    public void Gravityzero()
    {
        Physics.gravity = new Vector3(currentData.xAcceleration, currentData.yAcceleration, 0f);
    }
    public void Gravitynormal(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Physics.gravity = new Vector3(currentData.xAcceleration, currentData.gravity + currentData.yAcceleration, 0f);
        }
    }
}
