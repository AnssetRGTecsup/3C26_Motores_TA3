using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererControler : MonoBehaviour
{
    [SerializeField] private GameDataScriptableObject currentData;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private Transform originPosition;
    [SerializeField, Range(1f, 10f)] private float totalTime = 10f;
    [SerializeField, Range(0.0001f, 0.001f)] private float step = 0.01f;

    public bool testing = false;
    public Transform target;

    private void Start() {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update() {
        if(!testing) return;

        Vector3 distance = target.position - originPosition.position;

        float angle = Mathf.Atan2(distance.y, distance.x);
        float velocity = distance.magnitude;

        step = Mathf.Max(0.0001f, step);

        lineRenderer.positionCount = (int)(totalTime/step) + 2;

        float t = 0f;
        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            float x = velocity * Mathf.Cos(angle) * t + 0.5f * (currentData.xAcceleration) * Mathf.Pow(t,2);
            float y = velocity * Mathf.Sin(angle) * t - 0.5f * (-Physics.gravity.y + currentData.yAcceleration) * Mathf.Pow(t,2);
            lineRenderer.SetPosition(i, originPosition.position + new Vector3(x,y,0));

            t += step;
        }
    }

    public void SetLine(Vector2 velocityVector){
        if(testing) return;

        float angle = Mathf.Atan2(velocityVector.y, velocityVector.x);
        float velocity = velocityVector.magnitude;

        step = Mathf.Max(0.0001f, step);

        lineRenderer.positionCount = (int)(totalTime/step) + 2;


        float t = 0f;
        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            float x = velocity * Mathf.Cos(angle) * t + 0.5f * (currentData.xAcceleration) * Mathf.Pow(t,2);
            float y = velocity * Mathf.Sin(angle) * t - 0.5f * (-Physics.gravity.y) * Mathf.Pow(t,2);
            lineRenderer.SetPosition(i, originPosition.position + new Vector3(x,y,0));

            t += step;
        }
    }
}
