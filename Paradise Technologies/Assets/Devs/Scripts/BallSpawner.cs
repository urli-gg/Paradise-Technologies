using UnityEngine;
using System.Collections.Generic;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab;         // prefab de la pelota
    public int initialCount = 80;         // cu�ntas bolas en la piscina
    public Vector3 spawnAreaSize = new Vector3(3.6f, 0.6f, 3.6f); // �rea de spawn (dentro del contenedor)
    public float spawnHeight = 1.0f;      // altura base del spawn

    private List<GameObject> pool = new List<GameObject>();

    void Start()
    {
        if (ballPrefab == null) { Debug.LogError("Ball prefab no asignado"); return; }
        // Crear pool
        for (int i = 0; i < initialCount; i++)
        {
            GameObject b = Instantiate(ballPrefab, Vector3.zero, Quaternion.identity);
            b.SetActive(false);
            pool.Add(b);
        }
        // Rellenar el pit
        FillPit();
    }

    void FillPit()
    {
        foreach (GameObject b in pool)
        {
            Vector3 randomOffset = new Vector3(
                Random.Range(-spawnAreaSize.x / 2f, spawnAreaSize.x / 2f),
                Random.Range(0f, spawnAreaSize.y),
                Random.Range(-spawnAreaSize.z / 2f, spawnAreaSize.z / 2f)
            );
            Vector3 spawnPos = transform.position + new Vector3(0f, spawnHeight, 0f) + randomOffset;
            b.transform.position = spawnPos;
            b.transform.rotation = Random.rotation;
            b.SetActive(true);
            // Reset rigidbody velocities
            Rigidbody rb = b.GetComponent<Rigidbody>();
            if (rb != null) { rb.linearVelocity = Vector3.zero; rb.angularVelocity = Vector3.zero; }
        }
    }

    // M�todo p�blico para vaciar y volver a llenar si lo deseas
    public void RespawnAll()
    {
        foreach (GameObject b in pool)
        {
            b.SetActive(false);
        }
        FillPit();
    }
}

