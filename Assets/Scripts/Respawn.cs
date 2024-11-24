using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [Header("References")]
    public PlayerMovement pm;
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
        pm.transform.position = new Vector3(0, 0, 0);
        pm.dead = false;
        Invoke("RespawnOpen", 0.5f);
    }

    private void RespawnOpen()
    {
        respawnAni.Play("RespawnOpen");
    }
}
