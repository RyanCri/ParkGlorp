using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlane : MonoBehaviour
{
    [Header("References")]
    public Rigidbody rb;
    public PlayerMovement pm;
    public Animator respawnAni;
    private MeshCollider deathPlane;

    private void Start()
    {
        deathPlane = GetComponent<MeshCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // respawnAni.Play("RespawnClose");
        pm.dead = true;
    }

    
}
