using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chatTrigger : MonoBehaviour
{
    public TutorialHandler tutorialHandler;
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hello");
        tutorialHandler.tutorialState += 1;
        Destroy(this.gameObject);
    }
}
