using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelGoal : MonoBehaviour
{
    private Scene scene;

    void Start()
    {
        scene = SceneManager.GetActiveScene();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
            { 
                SceneManager.LoadScene(scene.buildIndex+1, LoadSceneMode.Single);

                print(scene.name);

                if(scene.name == "Level_01_Planet1") {
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                }
            }
    }
    
}
