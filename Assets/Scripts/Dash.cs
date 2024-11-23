using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    [Header("References")]
    public Transform mosa;
    public GameObject indi;
    private Rigidbody rb;
    private PlayerMovement pm;
    private RigidbodyConstraints originalConstraints;

    [Header("Dashing")]
    public float dashForce;
    public float dashUpwardForce;
    public float dashDuration;

    [Header("Cooldown")]
    public float dashCd;
    private float dashCdTimer;

    [Header("Input")]
    public KeyCode airDashKey = KeyCode.Mouse1;

    private bool aiming = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        pm = GetComponent<PlayerMovement>();

        originalConstraints = rb.constraints;
    }

    private void Update()
    {
        MyInput();

        if(aiming)
            Aim();

        if(dashCdTimer > 0)
            dashCdTimer -= Time.deltaTime;
    }

    private void MyInput()
    {
        if(Input.GetKeyDown(airDashKey))
            aiming = true;

        if(Input.GetKeyUp(airDashKey))
            AirDash();
    }

    private void AirDash()
    {
        aiming = false;
        indi.SetActive(false);
        rb.constraints = originalConstraints;

        if (dashCdTimer > 0) return;
        else dashCdTimer = dashCd;

        // reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        pm.dashing = true;

        Vector3 forceToApply = mosa.forward * dashForce + mosa.up * dashUpwardForce;

        delayedForceToApply = forceToApply;
        Invoke(nameof(DelayedDashForce), 0.025f);

        Invoke(nameof(ResetDash), dashDuration);
    }

    private Vector3 delayedForceToApply;
    private void DelayedDashForce()
    {
        rb.AddForce(delayedForceToApply, ForceMode.Impulse);
    }

    private void ResetDash()
    {
        pm.dashing = false;
    }

    private void Aim()
    {
        rb.constraints = RigidbodyConstraints.FreezePosition;
        indi.SetActive(true);
    }
}
