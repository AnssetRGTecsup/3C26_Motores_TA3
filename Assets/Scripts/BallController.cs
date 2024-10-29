using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BallController : MonoBehaviour
{
    [SerializeField] private MaterialController materialController;
    [SerializeField] private Rigidbody myRGBD;
    [SerializeField] private Transform originTransform;
    [SerializeField] private TrailRenderer trailRenderer;
    public event Action<Vector2> onLaunch;

    private void Start() {
        myRGBD = GetComponent<Rigidbody>();
        trailRenderer = GetComponent<TrailRenderer>();

        materialController.ChangeEmissionColor(MaterialChange.Normal);

        myRGBD.velocity = Vector3.zero;
        myRGBD.useGravity = false;
        trailRenderer.enabled = false;
    }
    public void OnEnable()
    {
        PowerUp.OnvelocityChange += UpdateVelocity;
    }
    public void OnDestroy()
    {
        PowerUp.OnvelocityChange -= UpdateVelocity;
    }

    public void LaunchSphere(Vector2 velocity){
        materialController.ChangeEmissionColor(MaterialChange.OnLaunch);

        myRGBD.velocity = velocity;
        myRGBD.useGravity = true;

        trailRenderer.enabled = true;
    }

    public void ResetPosition(){
        transform.position = originTransform.position;
        transform.rotation = Quaternion.identity;

        materialController.ChangeEmissionColor(MaterialChange.Normal);

        myRGBD.velocity = Vector3.zero;
        myRGBD.useGravity = false;
        trailRenderer.enabled = false;
    }
    public void UpdateVelocity(Vector2 Modifider)
    {
        if (Modifider == Vector2.up)
        {
            materialController.ChangeEmissionColor(MaterialChange.OnOnlyVertical);
        }else if (Modifider == Vector2.up)
        {
            materialController.ChangeEmissionColor(MaterialChange.OnOnlyHorizontal);
        }
            myRGBD.velocity = Vector3.Scale(myRGBD.velocity, Modifider);
    }
}
