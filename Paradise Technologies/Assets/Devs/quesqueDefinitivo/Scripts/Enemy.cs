using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 1;
    public GameObject deathVFX; // opcional: efecto al morir
    public AudioClip deathSfx;   // opcional: sonido al morir
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Si la bala usa trigger:
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            TakeDamage(1);
            Destroy(other.gameObject); // destruye la bala
        }
    }

    // Si prefieres OnCollisionEnter (si no es trigger):
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Bullet"))
        {
            TakeDamage(1);
            Destroy(collision.gameObject);
        }
    }

    void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (deathVFX != null) Instantiate(deathVFX, transform.position, Quaternion.identity);
        if (deathSfx != null)
        {
            if (audioSource == null) audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.PlayOneShot(deathSfx);
        }
        Destroy(gameObject);
    }
}

