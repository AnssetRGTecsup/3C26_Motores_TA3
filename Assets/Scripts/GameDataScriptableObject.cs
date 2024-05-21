using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameDataScriptableObject", menuName = "ScriptableObject/GameDataScriptableObject", order = 0)]
public class GameDataScriptableObject : ScriptableObject 
{
    public float gravity;
    public Vector2 accelerationModifier;

    [HideInInspector] public float xAcceleration{
        set{}
        get{return accelerationModifier.x;}
    }

    [HideInInspector] public float yAcceleration{
        set{}
        get{return accelerationModifier.y;}
    }
}
