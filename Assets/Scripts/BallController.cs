using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Rendering;

public class BallController : MonoBehaviour
{
    [SerializeField] private MaterialController materialController;
    [SerializeField] private Rigidbody myRGBD;
    [SerializeField] private Transform originTransform;
    [SerializeField] private TrailRenderer trailRenderer;
    public event Action<Vector2> onLaunch;
    //[SerializeField] private float ChangegravityX;
    //[SerializeField] private float ChangegravityY;
    // public static event Action<float, float> OngravityTrigger;
    public static event Action OngravityTrigger;
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
        if (other.CompareTag("Horizontal"))
        {
            myRGBD.linearVelocity = new Vector3(0f, myRGBD.linearVelocity.y, myRGBD.linearVelocity.z);
        }
        if (other.CompareTag("Vertical"))
        {
            myRGBD.linearVelocity = new Vector3(myRGBD.linearVelocity.x, 0f, myRGBD.linearVelocity.z);
        }
        if (other.CompareTag("Gravedad"))
        {
            //myRGBD.useGravity = false;
            // myRGBD.linearVelocity = new Vector3(0f, 0f, myRGBD.linearVelocity.z);
            OngravityTrigger.Invoke();
        }
    }
}
