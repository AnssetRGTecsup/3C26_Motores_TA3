using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GuiManager : MonoBehaviour
{   
    [SerializeField] private GameDataScriptableObject currentData;
    [SerializeField] private TMP_Text gravityText;
    [SerializeField] private RectTransform arrowImg;

    [SerializeField] private TMP_Text xAccText;
    [SerializeField] private TMP_Text yAccText;

    private Quaternion qx = Quaternion.identity;
    private Quaternion qy = Quaternion.identity;
    private Quaternion qz = Quaternion.identity;
    private Quaternion r = Quaternion.identity;

    private float anguloSen;
    private float anguloCos;

    private float angleX;

    private void Start() {
        gravityText.text = "g = " + currentData.gravity;

        xAccText.text = "Acc x = " + currentData.xAcceleration;
        yAccText.text = "Acc y = " + currentData.yAcceleration;

        float angleZ = Mathf.Atan2(currentData.yAcceleration, currentData.xAcceleration) * Mathf.Rad2Deg;

        anguloSen = Mathf.Sin(Mathf.Deg2Rad * angleZ * 0.5f);
        anguloCos = Mathf.Cos(Mathf.Deg2Rad * angleZ * 0.5f);
        qz.Set(0, 0, anguloSen, anguloCos);

        r = qy * qx * qz;

        arrowImg.rotation = r;
    }
}
