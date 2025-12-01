using UnityEngine;
using NaughtyAttributes;

public class CokeBottle : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField, Required] private Transform _spawnPoint;
    [SerializeField, Required] private Transform _despawnPoint;

    [Header("Settings")]
    [SerializeField] private float _moveSpeed = 1f;
    [SerializeField] private float _distanceToDespawn = 0.1f;

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, _despawnPoint.position, _moveSpeed * Time.fixedDeltaTime);

        if (Vector3.Distance(transform.position, _despawnPoint.position) <= _distanceToDespawn)
        {
            Respawn();
        }
    }

    private void Respawn()
    {
        transform.position = _spawnPoint.position;
    }
}
