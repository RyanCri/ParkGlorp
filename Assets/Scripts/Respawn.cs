using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [Header("References")]
    public PlayerMovement pm;
    public Rigidbody rb;
    private Animator respawnAni;

    private void Start()
    {
        respawnAni = GetComponent<Animator>();
    }

    private void Update()
    {
        if(pm.dead)
            RespawnStart();
    }

    private void RespawnStart()
    {
        respawnAni.Play("RespawnClose");
    }

    public void RespawnEnd()
    {
        rb.velocity = new Vector3(0, 0, 0);
        pm.transform.position = new Vector3(0, 0.5f, 0);
        pm.dead = false;
        Invoke("RespawnOpen", 0.5f);
        Debug.Log(pm.transform.position);
    }

    private void RespawnOpen()
    {
        respawnAni.Play("RespawnOpen");
    }
}
