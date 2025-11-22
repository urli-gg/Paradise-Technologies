using UnityEngine;
using UnityEngine.InputSystem; //  OJO: Input System nuevo

[RequireComponent(typeof(CharacterController))]
public class BasicMover : MonoBehaviour
{
    public float speed = 4f;
    public float gravity = -9.81f;
    public float mouseSensitivity = 0.15f; // ajusta a gusto
    public Transform cam; // arrastra tu Main Camera

    private CharacterController cc;
    private InputAction moveAction;
    private InputAction lookAction;

    private float vy;
    private float pitch; // rotación vertical de la cámara

    void Awake()
    {
        cc = GetComponent<CharacterController>();
    }

    void OnEnable()
    {
        // (igual que antes: defines y Enable de moveAction/lookAction)
        moveAction = new InputAction("Move");
        moveAction.AddCompositeBinding("2DVector")
            .With("Up", "<Keyboard>/w")
            .With("Down", "<Keyboard>/s")
            .With("Left", "<Keyboard>/a")
            .With("Right", "<Keyboard>/d");
        moveAction.AddCompositeBinding("2DVector")
            .With("Up", "<Keyboard>/upArrow")
            .With("Down", "<Keyboard>/downArrow")
            .With("Left", "<Keyboard>/leftArrow")
            .With("Right", "<Keyboard>/rightArrow");
        moveAction.AddBinding("<Gamepad>/leftStick");
        moveAction.Enable();

        lookAction = new InputAction("Look");
        lookAction.AddBinding("<Mouse>/delta");
        lookAction.AddBinding("<Gamepad>/rightStick");
        lookAction.Enable();

        // >>> Deja el cursor libre y visible
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void OnDisable()
    {
        moveAction?.Disable();
        lookAction?.Disable();
        // Nada con el cursor aquí
    }

    void Update()
    {
        Vector2 mv = moveAction.ReadValue<Vector2>();

        // Solo leemos “look” si RMB está presionado; si no, el puntero queda libre
        Vector2 look = Vector2.zero;
        if (Mouse.current != null && Mouse.current.rightButton.isPressed)
        {
            look = lookAction.ReadValue<Vector2>() * mouseSensitivity;
        }

        // Yaw (horizontal) en el cuerpo
        transform.Rotate(0f, look.x, 0f);

        // Pitch (vertical) sólo en la cámara
        if (cam)
        {
            pitch = Mathf.Clamp(pitch - look.y, -80f, 80f);
            cam.localEulerAngles = new Vector3(pitch, 0f, 0f);
        }

        // Movimiento relativo al jugador
        Vector3 fwd = Vector3.ProjectOnPlane(transform.forward, Vector3.up).normalized;
        Vector3 right = Vector3.ProjectOnPlane(transform.right, Vector3.up).normalized;
        Vector3 horiz = (fwd * mv.y + right * mv.x) * speed;

        // Gravedad
        if (cc.isGrounded) vy = -0.5f; else vy += gravity * Time.deltaTime;

        cc.Move((horiz + Vector3.up * vy) * Time.deltaTime);
    }
}
