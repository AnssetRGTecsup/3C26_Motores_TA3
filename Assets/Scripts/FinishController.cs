using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishController : MonoBehaviour
{
    public string sceneToLoad;
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Player")){
            Debug.Log("GANO!");
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")){
            Debug.Log("GANO!");
            SceneManager.LoadScene(sceneToLoad);

        }
    }
}
