using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObst : MonoBehaviour
{
    public GameObject obstacle;

    public float Interval = 7f;
    private float elapsed_time = 0.45f;

    private float _timer;


    private void Start()

    {
        SpawnObstacle();
    }

    public void Update()
    {

        if (_timer > Interval)
        {
            SpawnObstacle();
            _timer = 0;
        }

        _timer += Time.deltaTime;
    }

    public void SpawnObstacle()
    {


        Vector3 spawnPos = transform.position + new Vector3(0, Random.Range(-elapsed_time, elapsed_time));
        GameObject spawnedobstacle = Instantiate(obstacle, spawnPos, Quaternion.identity);

        Destroy(spawnedobstacle, 11f);
    }
}
