using UnityEngine;

public class BottleSpawner : MonoBehaviour
{
    public GameObject bottlePrefab;
    public Transform spawnPoint;
    public float spawnInterval = 2f;
    private float timer = 0f;

    [HideInInspector]
    public bool canSpawn = false;

    void Update()
    {
        if (!canSpawn) return; 

        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            GameObject obj = Instantiate(bottlePrefab, spawnPoint.position, spawnPoint.rotation);
            Destroy(obj, 5f);
            timer = 0f;
        }
    }
}
