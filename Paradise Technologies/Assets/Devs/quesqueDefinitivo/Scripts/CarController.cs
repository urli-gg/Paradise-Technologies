using UnityEngine;
using UnityEngine.UI;
public class CarController : MonoBehaviour
{
    [Header("Configuraci�n de Movimiento")]
    [Tooltip("Velocidad m�xima del auto en unidades por segundo")]
    [SerializeField] private float maxSpeed = 20f;

    [Tooltip("Qu� tan r�pido acelera el auto")]
    [SerializeField] private float accelerationRate = 5f;

    [Tooltip("Qu� tan r�pido desacelera cuando no aceleras")]
    [SerializeField] private float decelerationRate = 3f;

    [Tooltip("Sensibilidad del control del mouse (rotaci�n)")]
    [SerializeField] private float mouseSensitivity = 2f;

    [Header("Configuraci�n del Jugador")]
    [Tooltip("Transform donde aparecer� el jugador al salir del auto")]
    [SerializeField] private Transform exitPoint;

    [Tooltip("Referencia al GameObject del jugador")]
    [SerializeField] private GameObject player;

    [Tooltip("Distancia m�nima para mostrar el bot�n de subir")]
    [SerializeField] private float interactionDistance = 3f;

    [Header("UI Dieg�tica")]
    [Tooltip("Canvas en World Space con el bot�n de acelerar")]
    [SerializeField] private Canvas accelerateCanvas;

    [Tooltip("Bot�n de acelerar dentro del canvas")]
    [SerializeField] private Button accelerateButton;

    [Tooltip("Canvas con el bot�n de subir al auto")]
    [SerializeField] private Canvas enterCanvas;

    [Tooltip("Bot�n para subir al auto")]
    [SerializeField] private Button enterButton;

    private Rigidbody rb;
    private Camera mainCamera;
    private float currentSpeed = 0f;
    private bool isPlayerDriving = false;
    private bool isAccelerating = false;
    private CharacterController playerController;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main;

        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        if (player != null)
        {
            playerController = player.GetComponent<CharacterController>();
        }

        if (accelerateButton != null)
        {
            accelerateButton.onClick.AddListener(OnAccelerateButtonClick);
        }

        if (enterButton != null)
        {
            enterButton.onClick.AddListener(OnEnterButtonClick);
        }

        if (accelerateCanvas != null)
        {
            accelerateCanvas.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (isPlayerDriving)
        {
            HandleDrivingInput();
            CheckExitInput();
        }
        else
        {
            CheckPlayerProximity();
        }
    }

    void FixedUpdate()
    {
        if (isPlayerDriving)
        {
            ApplyMovement();
        }
    }
    private void HandleDrivingInput()
    {
        if (Input.GetMouseButton(0) || isAccelerating)
        {
            currentSpeed = Mathf.Lerp(currentSpeed, maxSpeed, accelerationRate * Time.deltaTime);
        }
        else
        {
            currentSpeed = Mathf.Lerp(currentSpeed, 0f, decelerationRate * Time.deltaTime);
        }

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(Vector3.up, mouseX);
    }
    private void ApplyMovement()
    {
        Vector3 forwardMovement = transform.forward * currentSpeed;
        rb.linearVelocity = new Vector3(forwardMovement.x, rb.linearVelocity.y, forwardMovement.z);
    }
    private void CheckExitInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitCar();
        }
    }
    private void CheckPlayerProximity()
    {
        if (player == null || enterCanvas == null || mainCamera == null) return;

        float distance = Vector3.Distance(transform.position, player.transform.position);
        bool shouldBeActive = distance <= interactionDistance && !isPlayerDriving;

        enterCanvas.gameObject.SetActive(shouldBeActive);

        if (shouldBeActive)
        {
            enterCanvas.transform.rotation = Quaternion.LookRotation(enterCanvas.transform.position - mainCamera.transform.position);
        }
    }
    private void OnAccelerateButtonClick()
    {
        isAccelerating = !isAccelerating;

        if (accelerateButton != null)
        {
            ColorBlock colors = accelerateButton.colors;
            colors.normalColor = isAccelerating ? Color.green : Color.white;
            accelerateButton.colors = colors;
        }
    }

    public void OnEnterButtonClick()
    {
        EnterCar();
        Debug.Log("Botón de subir al auto presionado.");
    }

    public void EnterCar()
    {
        if (player == null) return;

        isPlayerDriving = true;

        player.SetActive(false);

        if (playerController != null)
        {
            playerController.enabled = false;
        }

        if (enterCanvas != null)
        {
            enterCanvas.gameObject.SetActive(false);
        }

        if (accelerateCanvas != null)
        {
            accelerateCanvas.gameObject.SetActive(true);
        }

        SetupDrivingCamera();

        Debug.Log("Jugador subi� al auto. Presiona ESC para salir.");
    }
    public void ExitCar()
    {
        if (player == null) return;

        isPlayerDriving = false;
        isAccelerating = false;
        currentSpeed = 0f;

        if (exitPoint != null)
        {
            player.transform.position = exitPoint.position;
            player.transform.rotation = exitPoint.rotation;
        }
        else
        {
            player.transform.position = transform.position + transform.right * 2f;
        }

        player.SetActive(true);

        if (playerController != null)
        {
            playerController.enabled = true;
        }

        if (accelerateCanvas != null)
        {
            accelerateCanvas.gameObject.SetActive(false);
        }

        RestorePlayerCamera();

        Debug.Log("Jugador sali� del auto.");
    }
    private void SetupDrivingCamera()
    {
        if (mainCamera != null)
        {
            mainCamera.transform.SetParent(transform);
            mainCamera.transform.localPosition = new Vector3(0, 2f, -5f);
            mainCamera.transform.localRotation = Quaternion.Euler(10, 0, 0);
        }
    }
    private void RestorePlayerCamera()
    {
        if (mainCamera != null && player != null)
        {
            mainCamera.transform.SetParent(player.transform);
            mainCamera.transform.localPosition = new Vector3(0, 1.6f, 0);
            mainCamera.transform.localRotation = Quaternion.identity;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactionDistance);

        if (exitPoint != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(exitPoint.position, 0.5f);
        }
    }
}
