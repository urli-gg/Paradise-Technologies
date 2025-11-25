using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMunition : MonoBehaviour
{
    public GameObject munition;

    public float Interval = 7f;
    private float elapsed_time = 0.45f;

    private float _timer;


    private void Start()

    {
        SpawnAmmo();
    }

    public void Update()
    {

        if (_timer > Interval)
        {
            SpawnAmmo();
            _timer = 0;
        }

        _timer += Time.deltaTime;
    }

    public void SpawnAmmo()
    {


        Vector3 spawnPos = transform.position + new Vector3(0, Random.Range(-elapsed_time, elapsed_time));
        GameObject spawnedmunition = Instantiate(munition, spawnPos, Quaternion.identity);

        Destroy(spawnedmunition, 13f);
    }
    
}
