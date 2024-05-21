using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishController : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Player")){
            Debug.Log("GANO!");
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")){
            Debug.Log("GANO!");
        }
    }
}
