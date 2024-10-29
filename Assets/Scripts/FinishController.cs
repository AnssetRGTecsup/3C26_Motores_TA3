using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishController : MonoBehaviour
{
    [SerializeField] private string newScene;

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Player")){
            SceneManager.LoadScene(newScene);
        }
    }
}
