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

        myRGBD.linearVelocity = Vector3.zero;
        myRGBD.useGravity = false;
        trailRenderer.enabled = false;
    }
    private void OnEnable()
    {
        powerup.Oncollision+= OnCollide;
    }
    private void OnDisable()
    {
        powerup.Oncollision-= OnCollide;
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
    private void OnCollide(MaterialChange powerType)
    {
        materialController.ChangeEmissionColor(powerType);

        switch (powerType)
        {
            case MaterialChange.OnLaunch:
                break;
            case MaterialChange.OnOnlyVertical:
                myRGBD.linearVelocity = new Vector3(0,myRGBD.linearVelocity.y,0);
                break;
            case MaterialChange.OnOnlyHorizontal:
                myRGBD.linearVelocity = new Vector3(myRGBD.linearVelocity.x, 0,0);
                break;
            case MaterialChange.OnLooseGravity:
              //  myRGBD.linearVelocity = new Vector3(myRGBD.linearVelocity.x,0,0);
                break;
            default:
                break;
        }

    }
}
