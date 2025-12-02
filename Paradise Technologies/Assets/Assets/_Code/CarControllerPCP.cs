using UnityEngine;

public class CarControllerPCP : MonoBehaviour
{
    public float acceleration = 10f;
    public float turnSpeed = 50f;
    public Transform cameraTransform;
    public GameObject playerMesh;     // assign your player model here
    public CarController carController;

    private Rigidbody rb;
    private bool isDriving = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        enabled = false; // car not controllable yet
    }

    void FixedUpdate()
    {
        if (!isDriving) return;

        float moveInput = Input.GetAxis("Vertical");
        float turnInput = Input.GetAxis("Horizontal");

        Vector3 forward = transform.forward * moveInput * acceleration;
        rb.AddForce(forward, ForceMode.Acceleration);

        if (moveInput != 0)
        {
            float turn = turnInput * turnSpeed * Time.deltaTime;
            transform.Rotate(0, turn, 0);
        }
    }

    // Called when player enters the car
    public void StartDriving()
    {
        isDriving = true;
        playerMesh.SetActive(false); // hide the player mesh
    }

    // Called when car touches exit trigger
    public void StopDriving()
    {
        isDriving = false;
        playerMesh.SetActive(true);  // show the player mesh again
        enabled = false;             // stop controlling car
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
           StopDriving();
        }
    }

    public void OnCanvasGroupChanged()
    {
        if (CompareTag("Player"))
        {
            carController.enabled = true;
            StartDriving();
        }
    }
}
