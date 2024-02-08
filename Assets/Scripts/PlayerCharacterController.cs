using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterController : MonoBehaviour
{
    [Header("Movement")]
    public float walkSpeed;
    public float sprintSpeed;

    public float groundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    [SerializeField] float gravityScale;
    bool readyToJump;
    float currentSpeed;

    [Header("Dash")]
    [SerializeField] float dashSpeed;
    [SerializeField] float dashCooldown;
    bool isDashing;
    bool canDash;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode resetPosition = KeyCode.L;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;
    [SerializeField] Animator animator;
    [SerializeField] Transform spawnPoint;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        readyToJump = true;
        canDash = true;
    }

    private void Update()
    {
        if (isDashing)
            return;

        // ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.2f, whatIsGround);

        Debug.Log("Player velocity: " + rb.velocity.magnitude);

        MyInput();
        SpeedControl();
        Animations();

        // handle drag
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
    }

    private void FixedUpdate()
    {
        if (isDashing)
            return;

        MovePlayer();
        WorlBounds();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // when to jump
        if (Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;
            Jump();
            Invoke(nameof(ResetJump), jumpCooldown);

            //dash
            canDash = false;
        }

        // dash
        if (Input.GetKeyDown(KeyCode.E) && canDash)
            StartCoroutine(Dash());

        if (Input.GetKey(KeyCode.LeftShift))
            currentSpeed = sprintSpeed;
        else
            currentSpeed = walkSpeed;

        // reset position
        if (Input.GetKeyDown(resetPosition))
            RespawnPlayer();
    }

    void Animations()
    {
        if (moveDirection.magnitude != 0)
            animator.SetFloat("Speed", .6f);
        else if (moveDirection.magnitude > 7 && Input.GetKey(KeyCode.LeftShift))
            animator.SetFloat("Speed", 1.1f);
        else
            animator.SetFloat("Speed", 0);

        if (!grounded)
            animator.SetBool("isJumping", true);
        else if (grounded)
            animator.SetBool("isJumping", false);


        if (Input.GetMouseButton(0))
            animator.SetBool("isPunching", true);
        else if (Input.GetMouseButtonUp(0))
            animator.SetBool("isPunching", false);
    }

    private void MovePlayer()
    {
        // calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // on ground
        if (grounded)
            rb.AddForce(10f * currentSpeed * moveDirection.normalized, ForceMode.Force);

        // in air
        else if (!grounded)
        {
            rb.AddForce(10f * airMultiplier * currentSpeed * moveDirection.normalized, ForceMode.Force);
            // add gravity to the player
            rb.AddForce(gravityScale * rb.mass * Physics.gravity, ForceMode.Force);
        }
    }

    IEnumerator Dash()
    {
        isDashing = true;
        rb.AddForce(10f * dashSpeed * moveDirection.normalized, ForceMode.Impulse);
        // moveDirection = Vector3.zero;
        yield return new WaitForSeconds(dashCooldown);
        isDashing = false;
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new(rb.velocity.x, 0f, rb.velocity.z);

        // limit velocity if needed
        if (flatVel.magnitude > currentSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * currentSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        // reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    private void ResetJump()
    {
        readyToJump = true;
        canDash = true;
    }

    void WorlBounds()
    {
        if(transform.position.y < -20)
            RespawnPlayer();
    }

    void RespawnPlayer()
    {
        transform.SetPositionAndRotation(spawnPoint.position, spawnPoint.rotation);
        rb.angularVelocity = Vector3.zero;
        rb.velocity = Vector3.zero;
    }
}
