using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayers;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private Transform orientation;

    private Vector2 moveInput;
    private bool isGrounded;
    private bool isHoldingJump; 
    private Rigidbody rb;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void FixedUpdate()
    {

        if ( moveInput != Vector2.zero )
        {
            Vector3 moveDirection = orientation.forward * moveInput.y + orientation.right * moveInput.x;
            rb.AddForce( moveDirection.normalized * moveSpeed, ForceMode.Force );

            rb.linearVelocity = Vector3.ClampMagnitude(rb.linearVelocity, maxSpeed);

        }

        if ( isGrounded && isHoldingJump)
        {
            rb.AddForce( Vector3.up * jumpForce, ForceMode.Impulse);
            isHoldingJump = false; 
        }

    }

    private void Update()
    {
        LastTimeOnGround();
    }

    private void LastTimeOnGround()
    {

        // Checking if the character is grounded
        isGrounded = Physics.CheckBox(
        groundCheck.position,
        new Vector3( groundCheck.localScale.x * 0.5f, groundCheck.localScale.y * 0.1f ),
        Quaternion.identity,
        groundLayers
        );

    }

    public void Move( InputAction.CallbackContext context )
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void Jump(InputAction.CallbackContext context)
    {

        if (context.started)
        {
            isHoldingJump = true;
        }
        else if( context.canceled)
        {
            isHoldingJump = false;
        }
    }

}
