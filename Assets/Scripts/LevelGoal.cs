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
                print("yo");
                SceneManager.LoadScene(scene.buildIndex+1, LoadSceneMode.Single);
            }
    }
    
}
