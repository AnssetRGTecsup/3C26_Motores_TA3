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

    public static event Action OnGravityzero;
    public event Action<Vector2> onLaunch;

    private void Start() {
        myRGBD = GetComponent<Rigidbody>();
        trailRenderer = GetComponent<TrailRenderer>();

        materialController.ChangeEmissionColor(MaterialChange.Normal);

        myRGBD.linearVelocity = Vector3.zero;
        myRGBD.useGravity = false;
        trailRenderer.enabled = false;
    }

    public void LaunchSphere(Vector2 velocity){
        materialController.ChangeEmissionColor(MaterialChange.OnLaunch);

        myRGBD.linearVelocity = velocity;
        myRGBD.useGravity = true;

        trailRenderer.enabled = true;
    }

    public void ResetPosition(){
        transform.position = originTransform.position;
        transform.rotation = Quaternion.identity;

        materialController.ChangeEmissionColor(MaterialChange.Normal);

        myRGBD.linearVelocity = Vector3.zero;
        myRGBD.useGravity = false;
        trailRenderer.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HorizontalPowerUp"))
        {
            myRGBD.linearVelocity = new Vector3(0, myRGBD.linearVelocity.y, myRGBD.linearVelocity.z);
        }
        if (other.CompareTag("VerticalPowerUp"))
        {
            myRGBD.linearVelocity = new Vector3(myRGBD.linearVelocity.x, 0, myRGBD.linearVelocity.z);
        }
        if (other.CompareTag("GravityPowerUp"))
        {
            OnGravityzero?.Invoke();
        }
    }
}
