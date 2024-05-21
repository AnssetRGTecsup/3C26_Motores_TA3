using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseControls : MonoBehaviour
{
    [SerializeField] private Vector2 currentPosition;
    [Header("Mouse Values")]
    [SerializeField] private Vector2 initPosition;
    [SerializeField] private Vector2 endPosition;
    [SerializeField] private Vector2 differencePosition;

    [Header("Positions Game Objects")]
    [SerializeField] private GameObject initGo;
    [SerializeField] private GameObject endGo;

    [Header("Sphere Components")]
    [SerializeField] private BallController ballController;
    [SerializeField] private float speedModifier = 5f;

    [Header("Line Renderer")]
    [SerializeField] private LineRendererControler lineController;
    [SerializeField] private bool IsPressed;

    public void OnMouseClick(InputAction.CallbackContext context){

        switch (context.phase)
        {
            case InputActionPhase.Started:
            initPosition = ConvertToWorldPosition(currentPosition);
            initGo.transform.position = initPosition;

            initGo.SetActive(true);
            endGo.SetActive(false);

            IsPressed = true;
            break;

            case InputActionPhase.Canceled:
            endPosition = ConvertToWorldPosition(currentPosition);
            endGo.transform.position = endPosition;

            differencePosition = initPosition - endPosition;

            endGo.SetActive(true);

            LaunchMath(differencePosition * speedModifier);
            ballController.LaunchSphere(differencePosition * speedModifier);

            IsPressed = false;
            break;

            default:
            break;
        }
    }

    public void OnMousePosition(InputAction.CallbackContext context){
        currentPosition = context.ReadValue<Vector2>();

        if(IsPressed){
            LaunchMath((initPosition - (Vector2)ConvertToWorldPosition(currentPosition)) * speedModifier);
        }
    }

    public void OnRighClick(InputAction.CallbackContext context){
        if(context.performed){
            ballController.ResetPosition();
            initGo.SetActive(false);
            endGo.SetActive(false);
        }
    }

    public void LaunchMath(Vector2 velocityVector){
        float angle = Mathf.Atan2(velocityVector.y, velocityVector.x);
        float velocity = velocityVector.magnitude;

        lineController.SetLine(velocityVector);
    }

    private Vector3 ConvertToWorldPosition(Vector2 position){
        return MultiplyVector3(Camera.main.ScreenToWorldPoint(position), new Vector3(1,1,0));
    }

    public Vector3 MultiplyVector3(Vector3 v1, Vector3 v2){
        return new Vector3(v1.x*v2.x, v1.y*v2.y, v1.z*v2.z);
    }
}
