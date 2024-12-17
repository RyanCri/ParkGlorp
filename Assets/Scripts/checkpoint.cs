using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
{
    public Respawn respawn;
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("checkpointed");
        respawn.respawnLocation = this.transform.position;
    }
}
