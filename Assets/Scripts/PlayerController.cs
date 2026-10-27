using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    
    [Header("Movement Settings")]
    public float playerSpeed = 5.0f;
    public float runSpeed = 8.0f;
    public float jumpHeight = 1.5f;
    public float gravityValue = -20.0f;
    public float rotationSpeed = 10f;

    [Header("References")]
    public VirtualJoystick joystick;
    public Transform cameraTransform;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        if (cameraTransform == null && Camera.main != null)
        {
            cameraTransform = Camera.main.transform;
        }
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        float moveX = joystick != null ? joystick.Horizontal : Input.GetAxis("Horizontal");
        float moveZ = joystick != null ? joystick.Vertical : Input.GetAxis("Vertical");

        Vector3 move = new Vector3(moveX, 0, moveZ);
        
        if (move.magnitude > 0.1f)
        {
            Vector3 forward = cameraTransform.forward;
            Vector3 right = cameraTransform.right;
            forward.y = 0f;
            right.y = 0f;
            forward.Normalize();
            right.Normalize();

            Vector3 desiredMoveDirection = forward * move.z + right * move.x;
            
            Quaternion targetRotation = Quaternion.LookRotation(desiredMoveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            bool isRunning = Input.GetKey(KeyCode.LeftShift);
            float currentSpeed = isRunning ? runSpeed : playerSpeed;

            controller.Move(desiredMoveDirection * currentSpeed * Time.deltaTime);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
