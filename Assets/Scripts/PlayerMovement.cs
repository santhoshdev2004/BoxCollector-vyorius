using UnityEngine;
using Photon.Pun;

public class PlayerMovement : MonoBehaviourPunCallbacks
{
    [SerializeField] private float runSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpHeight;

    private Vector3 moveDirection;
    private Vector3 velocity;
    private CharacterController controller;
    private float gravity = 9.81f;

    [SerializeField] private LayerMask groundMask; // Define the ground layer
    private bool isGrounded;
    private Animator anim;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();

        // Only enable the control scripts for the local player
        if (photonView.IsMine)
        {
            // Enable scripts, camera, UI, etc. for the local player
            // Example: camera.enabled = true;
        }
        else
        {
            // Disable scripts, camera, UI, etc. for remote players
            // Example: camera.enabled = false;
        }
    }

    private void Update()
    {
        // Only process input and movement for the local player
        if (photonView.IsMine)
        {
            isGrounded = GroundCheck(); // Check if the player is grounded
            Move();

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Attack();
            }
        }
    }

    private bool GroundCheck()
    {
        float rayLength = 2.31f; // Adjust this value based on your character's size
        Vector3 rayOrigin = transform.position + Vector3.up * 0.1f; // Slightly above the player's feet

        // Visualize the ray (it will appear as a red line in the Scene view)
        Debug.DrawRay(rayOrigin, Vector3.down * rayLength, Color.red);

        if (Physics.Raycast(rayOrigin, Vector3.down, rayLength, groundMask))
        {
            return true;
        }

        return false;
    }

    private void Move()
    {
        float moveZ = Input.GetAxis("Vertical");
        moveDirection = new Vector3(0, 0, moveZ);
        moveDirection = transform.TransformDirection(moveDirection);

        if (isGrounded)
        {
            if (moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
            {
                walk();
            }
            else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
            {
                Run();
            }
            else if (moveDirection == Vector3.zero)
            {
                Idle();
            }
            moveDirection *= moveSpeed;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                jump();
            }
        }

        // Apply gravity to velocity.y when not grounded
        if (!isGrounded)
        {
            velocity.y -= gravity * Time.deltaTime;
        }

        controller.Move((moveDirection + velocity) * Time.deltaTime);
    }

    private void walk()
    {
        moveSpeed = walkSpeed;
        anim.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);
    }

    private void Run()
    {
        moveSpeed = runSpeed;
        anim.SetFloat("Speed", 1f, 0.1f, Time.deltaTime);
    }

    private void Idle()
    {
        anim.SetFloat("Speed", 0, 0.1f, Time.deltaTime);
    }

    private void jump()
    {
        float gravity2 = -9.81f;
        velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity2);
        anim.SetTrigger("Jump");
    }

    private void Attack()
    {
        anim.SetTrigger("Attack");
    }
}
