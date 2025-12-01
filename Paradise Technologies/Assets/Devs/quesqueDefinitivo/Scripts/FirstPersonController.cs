using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    [Header("Movimiento")]
    public float speed = 5f;
    public float gravity = -9.81f;
    public float jumpHeight = 2f;

    [Header("Mouse Look")]
    public float mouseSensitivity = 2f;
    public Transform playerCamera;

    private CharacterController controller;
    private float xRotation = 0f;
    private Vector3 velocity;
    private bool isGrounded;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked; // bloquea el cursor en el centro
    }

    public bool canMove = true;

    void Update()
    {
        IsGrounded();
        MouseLook();
        PlayerMovement();
        PlayerJump();
        ApplyGravity();
        IsGroundedTwo();
        PlayerJumpTwo();
        GravityTwo();
    }

    private void GravityTwo()
    {
        // Aplicar gravedad
        velocity.y += gravity * Time.deltaTime;

        // Mover verticalmente con gravedad
        controller.Move(velocity * Time.deltaTime);
    }

    private void PlayerJumpTwo()
    {
        // Salto
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    private void IsGroundedTwo()
    {
        // Detectar si está en el suelo
        isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < 0)
            velocity.y = -2f; // mantiene al jugador pegado al suelo
    }

    private void ApplyGravity()
    {
        // --- GRAVEDAD ---
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void PlayerJump()
    {
        // --- SALTO ---
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            // Fórmula física: v = √(h * -2 * g)
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    private void PlayerMovement()
    {
        // --- MOVIMIENTO CON TECLADO ---
        if (canMove)
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            Vector3 move = transform.right * x + transform.forward * z;
            controller.Move(move * speed * Time.deltaTime);
        }
    }

    private void MouseLook()
    {
        // --- ROTACIÓN CON EL MOUSE ---
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

    private void IsGrounded()
    {
        // --- DETECTAR SI ESTÁ EN EL SUELO ---
        isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < 0)
            velocity.y = -2f; // mantiene al jugador pegado al suelo
    }

    public void CanMove(bool value)
    {
        canMove = value;
    }
}

