using UnityEngine;

public class SpaceInvaderPlayer : MonoBehaviour
{
    [Header("Movimiento")]
    public float moveSpeed = 6f;
    public float xLimit = 4.5f; // l�mite horizontal

    [Header("Disparo")]
    public GameObject bulletPrefab; // assign Bullet prefab
    public Transform bulletSpawn;   // assign BulletSpawn (child)
    public float bulletForce = 12f;
    public float fireCooldown = 0.25f;
    float fireTimer = 0f;

    void OnEnable()
    {
        fireTimer = 0f;
    }

    void Update()
    {
        // Movimiento horizontal con A/D o izquierda/derecha. W/S pueden mover adelante/atr�s si quieres.
        float h = 0f;
        if (Input.GetKey(KeyCode.A)) h = -1f;
        if (Input.GetKey(KeyCode.D)) h = 1f;

        Vector3 pos = transform.position;
        pos.x += h * moveSpeed * Time.deltaTime;
        pos.x = Mathf.Clamp(pos.x, -xLimit, xLimit);
        transform.position = pos;

        // disparo con click izquierdo
        fireTimer -= Time.deltaTime;
        if (Input.GetMouseButton(0) && fireTimer <= 0f)
        {
            Fire();
            fireTimer = fireCooldown;
        }
    }

    void Fire()
    {
        if (bulletPrefab == null || bulletSpawn == null) return;
        GameObject b = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        Rigidbody rb = b.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = bulletSpawn.forward * bulletForce;
        }
        Destroy(b, 4f);
    }
}

