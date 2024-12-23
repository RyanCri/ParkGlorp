using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 7;
    public float walkSpeed = 7;
    public float wallRunSpeed;
    public float dashSpeed;

    public bool wallrunning;

    public float groundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump=true;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    public bool grounded;
    public bool dead;
    public bool kicking;

    [Header("Slope Handling")]
    public float maxSlopeAngle;
    private RaycastHit slopeHit;
    bool exitingSlope = true;

    public Transform orientation;
    public Transform mosa;

    float horizontalInput;
    float verticalInput;

    public Animator mimosaAnim;
    Vector3 moveDirection;
    
    Rigidbody rb;

    // stores current state
    public MovementState state;
    public enum MovementState
    {
        walking,
        wallrunning,
        dashing,
        dead,
        kicking,
        air
    }

    public bool dashing;

    // START OF CODE

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        // grounded check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);
        
        MyInput();
        AnimHandler();
        SpeedControl();
        StateHandler();

        // handle drag
        if (grounded)
            rb.drag = groundDrag;
        else 
            rb.drag = 0;

        // print(rb.velocity.magnitude);
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // when to jump
        if(Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }


    }

    private void AnimHandler()
    {
        if(grounded)
        {
            mimosaAnim.SetBool("isGrounded", true);
            if(rb.velocity.magnitude > 2)
            {
                mimosaAnim.SetBool("isRunning", true);
            }
            else
            {
                mimosaAnim.SetBool("isRunning", false);
            }
        }
        else
        {
            mimosaAnim.SetBool("isGrounded", false);
        }
    }

    private void StateHandler()
    {
        // Dashing
        if(dashing)
        {
            state = MovementState.dashing;
            moveSpeed = dashSpeed;
        }
        else if(grounded)
        {
            state = MovementState.walking;
            moveSpeed = walkSpeed;
        }
        // air
        else
        {
            state = MovementState.air;
            moveSpeed = walkSpeed;

            mimosaAnim.SetBool("isWallriding", false);
        }

        // wallrunning
        if(wallrunning)
        {
            state = MovementState.wallrunning;
            moveSpeed = wallRunSpeed;

            mimosaAnim.SetBool("isWallriding", true);

            print("WALLRUINNGIN");
        }
        // Mode - walking
        
        // kick
        if(kicking)
        {
            state = MovementState.kicking;

            mimosaAnim.SetBool("isKicking", true);
        }
        else 
        {
            mimosaAnim.SetBool("isKicking", false);
        }
    }

    private void MovePlayer()
    {
        // calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // on slope
        if(OnSlope() && !exitingSlope)
        {
            rb.AddForce(GetSlopeMoveDirection() * moveSpeed * 20f, ForceMode.Force);

            if(rb.velocity.y > 0)
                rb.AddForce(Vector3.down * 80f, ForceMode.Force);
        }

        // on ground
        if(grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        
        else if(!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
    }

    private void SpeedControl()
    {
        // limited slope speed
        if (OnSlope() && !exitingSlope)
        {
            if(rb.velocity.magnitude > moveSpeed)
                rb.velocity = rb.velocity.normalized * moveSpeed;
        }
        
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        exitingSlope = true;
        
        // reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);

        mimosaAnim.Play("metarig|jumping");
    }

    private void ResetJump()
    {
        readyToJump = true;

        exitingSlope = false;
        
    }

    private bool OnSlope()
    {
        if(Physics.Raycast(transform.position, Vector3.down, out slopeHit, playerHeight * 0.5f + 0.3f))
        {
            float angle = Vector3.Angle(Vector3.up, slopeHit.normal);
            return angle < maxSlopeAngle && angle != 0;
        }

        return false;
    }

    private Vector3 GetSlopeMoveDirection()
    {
        return Vector3.ProjectOnPlane(moveDirection, slopeHit.normal).normalized;
    }
}
