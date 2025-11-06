using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameDataScriptableObject currentData;
    public static GameManager instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }

        instance = this;
    }

    void Start()
    {
        ChangeGravity();
    }

    public void ChangeGravity(bool b = false)
    {
        if (b)
        {
            Physics.gravity = new Vector3(currentData.xAcceleration, currentData.yAcceleration, 0f);
        }
        else
        {
            Physics.gravity = new Vector3(currentData.xAcceleration, currentData.gravity + currentData.yAcceleration, 0f);
        }
    }
}
