using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FinishController : MonoBehaviour
{
    [SerializeField] private string scene;
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Player")){           
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")){
            SceneManager.LoadScene(scene);
        }
    }
}
