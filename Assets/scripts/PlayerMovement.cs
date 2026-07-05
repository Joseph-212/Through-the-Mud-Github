using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;


    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;


    private Rigidbody rb;
    private UnityEngine.Vector2 moveInput;
    private bool isGrounded;
    private PlayerInput playerInput;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = new PlayerInput();
    }



    void Update()
    {
        CheckGround();
    }
   private void FixedUpdate()
    {
        MovePlayer();
    }

    void OnJump ()
    {
        if (isGrounded) 
     { 

        rb.AddForce(new UnityEngine.Vector3(0, jumpForce, 0), ForceMode.Impulse);
     }

    }

    void CheckGround ()
    {
       isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask); 
    }

    void OnMovement(InputValue value)
    {
        moveInput = value.Get<UnityEngine.Vector2>();
    }

    void MovePlayer ()
    {
        UnityEngine.Vector3 direction = transform.right * moveInput.x + transform.forward * moveInput.y;
        direction.Normalize();
        rb.linearVelocity = new UnityEngine.Vector3(direction.x * moveSpeed, rb.linearVelocity.y, direction.z * moveSpeed);
    }
}





