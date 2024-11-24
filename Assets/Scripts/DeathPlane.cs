using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlane : MonoBehaviour
{
    [Header("References")]
    public Rigidbody rb;
    public PlayerMovement pm;
    private MeshCollider deathPlane;

    private void Start()
    {
        deathPlane = GetComponent<MeshCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        print(other);
        other.transform.parent.position = new Vector3(0, 0, 0);
    }

    
}
