using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "MaterialController", menuName = "ScriptableObject/MaterialController", order = 0)]
public class MaterialController : ScriptableObject
{
    [SerializeField] private Material ballMaterial;
    [SerializeField] private Color[] emissionsColors;
    
    public void ChangeEmissionColor(MaterialChange typeChange){
        switch (typeChange)
        {
            case MaterialChange.OnLaunch:
            ballMaterial.SetColor("_emissionColor", emissionsColors[0]);
            break;
            case MaterialChange.OnOnlyVertical:
            ballMaterial.SetColor("_emissionColor", emissionsColors[1]);
            break;
            case MaterialChange.OnOnlyHorizontal:
            ballMaterial.SetColor("_emissionColor", emissionsColors[2]);
            break;
            case MaterialChange.OnLooseGravity:
            ballMaterial.SetColor("_emissionColor", emissionsColors[3]);
            break;
            default:
            ballMaterial.SetColor("_emissionColor", emissionsColors[4]);
            break;
        }
    }
}


public enum MaterialChange
{
    OnLaunch, OnOnlyVertical, OnOnlyHorizontal, OnLooseGravity, Normal
}