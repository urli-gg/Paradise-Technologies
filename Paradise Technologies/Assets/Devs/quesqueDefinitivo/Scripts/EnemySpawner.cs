using UnityEngine;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    [Header("Prefab y layout")]
    public GameObject enemyPrefab;
    public int rows = 4;
    public int cols = 8;
    public Vector2 spacing = new Vector2(1.4f, 1.0f);
    public Vector3 startOffset = new Vector3(-5.0f, 1.5f, 8f);

    [Header("Movimiento de grupo")]
    public float speed = 1.5f;
    public float horizontalLimit = 6.5f;  // cuánto puede ir a la izquierda/derecha antes de invertir
    public float descendAmount = 0.6f;
    private Vector3 direction = Vector3.right;

    List<Transform> enemies = new List<Transform>();
    Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
        SpawnGrid();
    }

    void SpawnGrid()
    {
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                Vector3 pos = transform.position + startOffset + new Vector3(c * spacing.x, -r * spacing.y, 0f);
                GameObject e = Instantiate(enemyPrefab, pos, Quaternion.identity, transform);
                enemies.Add(e.transform);
            }
        }
    }

    void Update()
    {
        if (enemies.Count == 0) return;

        // mover todo el grupo (se mueve el transform padre)
        transform.Translate(direction * speed * Time.deltaTime, Space.World);

        // comprobar límites: si algún enemigo sobrepasa el límite horizontal, invertir y descender
        foreach (var t in enemies.ToArray())
        {
            if (t == null)
            {
                enemies.Remove(t); // limpio nulls de enemigos destruidos
                continue;
            }

            if (Mathf.Abs(t.position.x - initialPosition.x) > horizontalLimit)
            {
                // invertimos dirección y bajamos
                direction = -direction;
                transform.position += new Vector3(0f, -descendAmount, 0f);
                break;
            }
        }
    }

    // opcional: llamada pública para limpiar la lista si destruyes enemigos por fuera
    public void NotifyEnemyDestroyed(Transform enemy)
    {
        if (enemies.Contains(enemy)) enemies.Remove(enemy);
    }
}

