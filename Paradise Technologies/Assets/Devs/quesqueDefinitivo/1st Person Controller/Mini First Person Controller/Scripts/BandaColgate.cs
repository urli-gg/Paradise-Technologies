using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    public float speed = 2f;
    void OnCollisionStay(Collision collision)
    {
        Rigidbody rb = collision.rigidbody;
        if (rb != null)
        {
            rb.AddForce(transform.forward * speed, ForceMode.VelocityChange);
        }
    }
}
