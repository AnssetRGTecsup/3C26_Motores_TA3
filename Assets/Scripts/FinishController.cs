using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FinishController : MonoBehaviour
{
    [SerializeField] private string newScene;
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")){
            SceneManager.LoadScene(newScene);
        }
    }
}
