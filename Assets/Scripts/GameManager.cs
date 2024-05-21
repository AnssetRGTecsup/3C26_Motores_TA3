using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
