using UnityEngine;

public class BottleSpawner : MonoBehaviour
{
    public GameObject bottlePrefab;
    public Transform spawnPoint;
    public float spawnInterval = 1.5f;  
    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            Instantiate(bottlePrefab, spawnPoint.position, spawnPoint.rotation);
            timer = 0f;
        }
    }
}
