using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kick : MonoBehaviour
{
    [Header("References")]
    public Transform orientation;
    public GameObject kickCollider;
    public Collider kickCollisionBox;
    private PlayerMovement pm;
    public LayerMask whatIsDestructible;
    public LayerMask whatIsKick;

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

    private void OnTriggerEnter(Collider collider)
    {
        print(LayerMask.LayerToName(12));
        print(collider.gameObject.layer);

        if(collider.gameObject.layer == 12)
        {
            collider.gameObject.SetActive(false);
        }
    }

    private void KickAttack()
    {
        pm.kicking = true;
        Invoke("KickBox", 0.5f);
        Invoke("KickEnd", 1.0f);
    }

    private void KickBox()
    {
        kickCollider.SetActive(true);

    }

    private void KickEnd()
    {
        kickCollider.SetActive(false);
        pm.kicking = false;
    }
}
