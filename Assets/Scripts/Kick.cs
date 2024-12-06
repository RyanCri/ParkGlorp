using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kick : MonoBehaviour
{
    [Header("References")]
    public Transform orientation;
    public GameObject kickCollider;
    private PlayerMovement pm;

    [Header("Keybinds")]
    public KeyCode kickKey = KeyCode.Mouse0;

    private void Start()
    {
        pm = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        MyInput();
    }

    private void MyInput()
    {
        if(Input.GetKeyDown(kickKey))
            KickAttack();
    }

    private void KickAttack()
    {
        kickCollider.SetActive(true);
        pm.kicking = true;
        Invoke("KickEnd", 1.0f);
    }

    private void KickEnd()
    {
        kickCollider.SetActive(false);
        pm.kicking = false;
    }
}
