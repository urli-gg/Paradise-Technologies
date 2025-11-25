using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject bulletModel;
    public float bulletSpeed = 10;

    public void Shoot()
    {
        if (Input.GetMouseButtonDown(0) && PlayerManager.Shooting)
        {
            var bullet = Instantiate(bulletModel, spawnPoint.position, spawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().linearVelocity = spawnPoint.forward * bulletSpeed;
        }
    }

    
}
