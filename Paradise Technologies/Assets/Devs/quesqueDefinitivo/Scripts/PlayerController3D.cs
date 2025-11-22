using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController3D : MonoBehaviour
{
    public float moveSpeed = 6f;      // velocidad de movimiento
    public float turnSpeed = 8f;      // suavizado de rotaci�n
    Rigidbody rb;
    Vector3 inputDir;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Obtener input
        float h = Input.GetAxisRaw("Horizontal"); // A/D o flechas
        float v = Input.GetAxisRaw("Vertical");   // W/S o flechas

        inputDir = new Vector3(h, 0f, v).normalized;
        // Rotaci�n hacia direcci�n de movimiento si hay input
        if (inputDir.sqrMagnitude > 0.001f)
        {
            Quaternion targetRot = Quaternion.LookRotation(inputDir, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, turnSpeed * Time.deltaTime);
        }
    }

    void FixedUpdate()
    {
        // Mover con Rigidbody para empujar objetos con f�sica
        Vector3 velocity = transform.forward * (inputDir.z) + transform.right * (inputDir.x);
        velocity = velocity.normalized * moveSpeed;
        Vector3 currentVel = rb.linearVelocity;
        // Mantener componente Y (gravedad)
        Vector3 newVel = new Vector3(velocity.x, currentVel.y, velocity.z);
        rb.linearVelocity = newVel;
    }
}

