using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishController : MonoBehaviour
{
     public string Nivel;

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")){
            Debug.Log("GANO!");
            SceneManager.LoadScene(Nivel);
        }
    }
}
