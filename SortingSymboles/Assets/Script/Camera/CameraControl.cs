using UnityEngine;
using UnityEngine.InputSystem;

public class CameraControl : MonoBehaviour
{

    [SerializeField] private float lookSpeedX = 2.0f; // Horizontal look speed
    [SerializeField] private float lookSpeedY = 2.0f; // Vertical look speed
    [SerializeField] private float minYRotation = -80f; // Min vertical angle
    [SerializeField] private float maxYRotation = 80f;  // Max vertical angle
    [SerializeField] private Transform orientation;

    private float rotationX = 0f; // Current X (vertical) rotation
    private float rotationY = 0f; // Current Y (horizontal) rotation

    private void Start()
    {
        Cursor.visible = false; // Hides the cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Look(InputAction.CallbackContext context)
    {
        // Get input from the context
        Vector2 lookInput = context.ReadValue<Vector2>();

        // Adjust the vertical and horizontal rotation based on input
        rotationX -= lookInput.y * lookSpeedY; // Inverted vertical movement
        rotationY += lookInput.x * lookSpeedX; // Horizontal movement

        // Clamp the vertical rotation to prevent the camera from rotating too far
        rotationX = Mathf.Clamp(rotationX, minYRotation, maxYRotation);

        // Apply the rotation to the camera and the player
        transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0);
        orientation.localRotation = Quaternion.Euler( 0, rotationY, 0);
    }

}
