using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FPSController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 6f;
    
    public float gravity = -9.81f;
    public float jumpHeight = 1.5f;

    [Header("Mouse Look")]
    public float mouseSensitivity = 100f;
    public Transform playerCamera;

    private CharacterController controller;
    private float yVelocity;
    private float xRotation = 0f;
    [Header("Lives")]
    public LivesUI livesUI;



    


    void Start()
    {
        controller = GetComponent<CharacterController>();

        // Lock cursor to center
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        HandleMouseLook();
        HandleMovement();
    }

    void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Vertical camera rotation
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Horizontal player rotation
        transform.Rotate(Vector3.up * mouseX);
    }

    void HandleMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        if (controller.isGrounded && yVelocity < 0)
        {
            yVelocity = -2f;
        }

        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            yVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        yVelocity += gravity * Time.deltaTime;

        Vector3 velocity = move * moveSpeed + Vector3.up * yVelocity;

        controller.Move(velocity * Time.deltaTime);
    }
    void OnControllerColliderHit(ControllerColliderHit hit)
{
    if (hit.gameObject.CompareTag("Enemy"))
    {
        livesUI.TakeDamage(1);       
    }
}
}