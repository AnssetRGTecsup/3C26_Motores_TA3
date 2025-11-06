using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "MaterialController", menuName = "ScriptableObject/MaterialController", order = 0)]
public class MaterialController : ScriptableObject
{
    [SerializeField] private Material ballMaterial;
    [SerializeField] private Color[] emissionsColors;

    private void OnEnable()
    {
        powerup.Oncollision += ChangeEmissionColor;
    }
    private void OnDisable()
    {
        powerup.Oncollision -= ChangeEmissionColor;
    }

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
public enum ColorDisplay { 

}

[CreateAssetMenu(fileName = "MaterialController", menuName = "ScriptableObject/MaterialController", order = 0)]
public class ColorPalleteSO : ScriptableObject {
    [SerializeField] public List<ColorDisplay> keys;
    [SerializeField] public Color[] colors;
    [SerializeField] public string[] colorsname ;

    private Dictionary<ColorDisplay, Color> paletteColor = new Dictionary<ColorDisplay, Color>();
    public Dictionary<ColorDisplay, Color> PaletteColor => paletteColor;

    private void OnEnable()
    {
        if (hexColor.) { }
        
        for (int i = 0; i < colors.Length; i++) {
            Color newColor = new Color();
            paletteColor.Add(keys[i], colors[i]);
        }
    }
    private void OnDisable()
    {
        paletteColor.Clear(); 
    }
}
public class UIDisplayManager : MonoBehaviour {
    [SerializeField] private ColorPalleteSO colorPallete;

    public static event Action<Dictionary<ColorDisplay,Color>> OnChangeColors;

    public void OnSpaceBarPressed(InputAction.CallbackContext context) {
        if (context.performed) {
            OnChangeColors?.Invoke(colorPallete.PaletteColor);
        }
    }
}
public class DisplayColorController : MonoBehaviour {
    [SerializeField] private ColorDisplay typeDisplay;
    private void OnEnable()
    {
        UIDisplayManager.OnChangeColors += HandleColorChange;
    }
    private void OnDisable()
    {
        UIDisplayManager.OnChangeColors -= HandleColorChange;
    }

    public void HandleColorChange(Dictionary<ColorDisplay, Color> dictionary)
    {
        ChangeColor(dictionary[typeDisplay]);
    }
    protected abstract void ChangeColor(Color newColor);
}
public class LineColorDisplay : UIDisplayManager
{
    [SerializeField] private LineRenderer lineRenderer;
    protected override void ChangeColor(Color newcolor) {

        Gradient newGradient = new Gradient();
        GradientColorKey[] colorKeys = newcolor;
    }
}
public class RenderColorDisplay : DisplayColorController {
    [SerializeField] private Camera cameraRender;

    protected override void ChangeColor(Color newColor)
    {
        cameraRender.backgroundColor = newColor;
    }
}
public class ImageColorDisplay : DisplayColorController {
    [SerializeField] private TMP_Text textRenderer;
    protected override void ChangeColor(Color newColor)
    {
        textRenderer.;
    }
}
